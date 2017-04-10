using AutoMapper;
using Survey.Model.Common;
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

        public AspNetUserController(IAspNetUserService _aspNetUserService)
        {
            this.AspNetUserService = _aspNetUserService;
        }

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
                aspNetUser.Id = Guid.NewGuid().ToString();
                var entity = await AspNetUserService.Add(Mapper.Map<IAspNetUserDomain>(aspNetUser));
                return Request.CreateResponse(HttpStatusCode.OK, entity);
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
