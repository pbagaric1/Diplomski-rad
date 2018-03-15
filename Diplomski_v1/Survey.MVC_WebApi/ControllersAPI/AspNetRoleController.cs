using AutoMapper;
using Survey.Repository.Common.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Survey.DAL.Models;

namespace Survey.MVC_WebApi.ControllersAPI
{
    [RoutePrefix("api/roles")]
    public class AspNetRoleController : ApiController
    {
        private IAspNetRoleRepository AspNetRoleRepository;

        public AspNetRoleController(IAspNetRoleRepository _AspNetRoleRepository)
        {
            this.AspNetRoleRepository = _AspNetRoleRepository;
        }

        [Route("getall")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetAll()
        {
            try
            {
                var entity = (await AspNetRoleRepository.GetAll());
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
                var entity = Mapper.Map<AspNetRole>(await AspNetRoleRepository.Get(id));
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Not found.");
            }
        }

        [Route("add")]
        [HttpPost]
        public async Task<HttpResponseMessage> Add(AspNetRole aspNetRole)
        {
            try
            {
                aspNetRole.Id = Guid.NewGuid().ToString();
                var entity = await AspNetRoleRepository.Add(aspNetRole);
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
                var entity = await AspNetRoleRepository.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error");
            }

        }

        [Route("edit")]
        [HttpPut]
        public async Task<HttpResponseMessage> Edit(AspNetRole aspNetRole)
        {
            try
            {
                var toBeUpdated = Mapper.Map<AspNetRole>(await AspNetRoleRepository.Get(aspNetRole.Id));

                if (toBeUpdated == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Entry not found");

                toBeUpdated.Name = aspNetRole.Name;


                var response = await AspNetRoleRepository.Update((toBeUpdated));
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Wrong input.");
            }
        }
    }
}
