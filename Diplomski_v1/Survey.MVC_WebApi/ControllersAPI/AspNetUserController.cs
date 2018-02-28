using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Survey.Model.Common;
using Survey.MVC_WebApi.Models;
using Survey.MVC_WebApi.ViewModels;
using Survey.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Survey.MVC_WebApi.ControllersAPI
{
    [RoutePrefix("api/user")]
    public class AspNetUserController : ApiController
    {
        private IAspNetUserService AspNetUserService;

        private ApplicationDbContext context;

        public AspNetUserController(IAspNetUserService _aspNetUserService, ApplicationDbContext _context)
        {
            this.AspNetUserService = _aspNetUserService;
            this.context = _context;
        }

        [Authorize(Roles = "Admin, Ispitivac")]
        [Route("getall")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetAll()
        {
            try
            {
                var entity = Mapper.Map<IEnumerable<AspNetUserView>>(await AspNetUserService.GetAll());
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Not found.");
            }
        }

        [Route("getallusernames")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetAllUsernames()
        {
            try
            {
                var entity = Mapper.Map<IEnumerable<AspNetUserView>>(await AspNetUserService.GetAllUsernames());
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Not found.");
            }
        }

        [Route("getallemails")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetAllEmails()
        {
            try
            {
                var entity = Mapper.Map<IEnumerable<AspNetUserView>>(await AspNetUserService.GetAllEmails());
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Not found.");
            }
        }

        [Route("get")]
        [HttpGet]
        public async Task<HttpResponseMessage> Get(string id)
        {
            try
            {
                var entity = Mapper.Map<AspNetUserView>(await AspNetUserService.Get(id));
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Not found.");
            }
        }

        [Route("getbyusername")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetByUsername(string username)
        {
            try
            {
                var entity = Mapper.Map<AspNetUserView>(await AspNetUserService.GetByUsername(username));
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Not found.");
            }
        }

        [Route("add")]
        [HttpPost]
        public async Task<HttpResponseMessage> Add(AspNetUserView aspNetUser)
        {
            try
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                aspNetUser.Id = Guid.NewGuid().ToString();
                aspNetUser.SecurityStamp = Guid.NewGuid().ToString();

                ApplicationUser user = new ApplicationUser()
                {
                    Id = aspNetUser.Id,
                    UserName = aspNetUser.UserName,
                    Age = aspNetUser.Age,
                    Address = aspNetUser.Address,
                    Place = aspNetUser.Place,
                    UserRole = aspNetUser.UserRole  
                };


                //hash the password using the microsoft identity password hasher
                //var hashedPassword = UserManager.PasswordHasher.HashPassword(aspNetUser.PasswordHash);
                //aspNetUser.PasswordHash = hashedPassword;

                var result = await userManager.CreateAsync(user, aspNetUser.PasswordHash);
                var addToRole = userManager.AddToRole(user.Id, aspNetUser.UserRole);
                //var entity = await AspNetUserService.Add(Mapper.Map<IAspNetUserDomain>(aspNetUser)); 
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error");
            }

        }

        [Route("delete")]
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(string id)
        {
            try
            {
                var entity = await AspNetUserService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error");
            }

        }

        [Route("edit")]
        [HttpPut]
        public async Task<HttpResponseMessage> Edit(AspNetUserView aspNetUser)
        {
            try
            {
                var toBeUpdated = Mapper.Map<AspNetUserView>(await AspNetUserService.Get(aspNetUser.Id));

                if (toBeUpdated == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Entry not found");

                toBeUpdated.Address = aspNetUser.Address;
                toBeUpdated.Age = aspNetUser.Age;
                toBeUpdated.Email = aspNetUser.Email;
                toBeUpdated.FirstName = aspNetUser.FirstName;
                toBeUpdated.LastName = aspNetUser.LastName;
                toBeUpdated.Place = aspNetUser.Place;

                var response = await AspNetUserService.Update(Mapper.Map<IAspNetUserDomain>(toBeUpdated));
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Wrong input.");
            }
        }
}
}
