using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Survey.MVC_WebApi.Models;
using Survey.Repository.Common.IRepositories;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Survey.DAL.Models;

namespace Survey.MVC_WebApi.ControllersAPI
{
    [RoutePrefix("api/user")]
    public class AspNetUserController : ApiController
    {
        private IAspNetUserRepository AspNetUserRepository;

        private ApplicationDbContext context;

        public AspNetUserController(IAspNetUserRepository _AspNetUserRepository, ApplicationDbContext _context)
        {
            this.AspNetUserRepository = _AspNetUserRepository;
            this.context = _context;
        }

        [Authorize(Roles = "Admin, Ispitivac")]
        [Route("getall")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetAll()
        {
            try
            {
                var entity = (await AspNetUserRepository.GetAll());
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
                var entity = (await AspNetUserRepository.GetAllUsernames());
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
                var entity = (await AspNetUserRepository.GetAllEmails());
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
                var entity = (await AspNetUserRepository.Get(id));
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
                var entity = await AspNetUserRepository.GetByUsername(username);
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Not found.");
            }
        }

        [Route("add")]
        [HttpPost]
        public async Task<HttpResponseMessage> Add(AspNetUser aspNetUser)
        {
            try
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                aspNetUser.Id = Guid.NewGuid().ToString();
                aspNetUser.SecurityStamp = Guid.NewGuid().ToString();

                ApplicationUser user = new ApplicationUser()
                {
                    Id = aspNetUser.Id,
                    Age = aspNetUser.Age,
                    City = aspNetUser.City,
                    UserRole = aspNetUser.UserRole,
                    Email = aspNetUser.Email,
                    UserName = aspNetUser.UserName
                };


                //hash the password using the microsoft identity password hasher
                //var hashedPassword = UserManager.PasswordHasher.HashPassword(aspNetUser.PasswordHash);
                //aspNetUser.PasswordHash = hashedPassword;

                var result = await userManager.CreateAsync(user, aspNetUser.PasswordHash);

                if(result.Succeeded)
                    result = userManager.AddToRole(user.Id, aspNetUser.UserRole);
                //var entity = await AspNetUserRepository.Add(Mapper.Map<IAspNetUserDomain>(aspNetUser)); 
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);

            }

        }

        [Route("delete")]
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(string id)
        {
            try
            {
                var entity = await AspNetUserRepository.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error");
            }

        }

        [Route("edit")]
        [HttpPut]
        public async Task<HttpResponseMessage> Edit(AspNetUser aspNetUser)
        {
            try
            {
                var toBeUpdated = (await AspNetUserRepository.Get(aspNetUser.Id));

                if (toBeUpdated == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Entry not found");

                toBeUpdated.Age = aspNetUser.Age;
                toBeUpdated.Email = aspNetUser.Email;
                toBeUpdated.FirstName = aspNetUser.FirstName;
                toBeUpdated.LastName = aspNetUser.LastName;
                toBeUpdated.City = aspNetUser.City;

                var response = await AspNetUserRepository.Update((toBeUpdated));
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Wrong input.");
            }
        }
}
}
