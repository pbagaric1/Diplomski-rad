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
    [RoutePrefix("api/roles")]
    public class AspNetRoleController : ApiController
    {
        private IAspNetRoleService AspNetRoleService;

        public AspNetRoleController(IAspNetRoleService _aspNetRoleService)
        {
            this.AspNetRoleService = _aspNetRoleService;
        }

        [Route("getall")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetAll()
        {
            try
            {
                var entity = Mapper.Map<IEnumerable<AspNetRoleView>>(await AspNetRoleService.GetAll());
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
                var entity = Mapper.Map<AspNetRoleView>(await AspNetRoleService.Get(id));
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Not found.");
            }
        }

        [Route("add")]
        [HttpPost]
        public async Task<HttpResponseMessage> Add(AspNetRoleView aspNetRole)
        {
            try
            {
                aspNetRole.Id = Guid.NewGuid().ToString();
                var entity = await AspNetRoleService.Add(Mapper.Map<IAspNetRoleDomain>(aspNetRole));
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
                var entity = await AspNetRoleService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error");
            }

        }

        [Route("edit")]
        [HttpPut]
        public async Task<HttpResponseMessage> Edit(AspNetRoleView aspNetRole)
        {
            try
            {
                var toBeUpdated = Mapper.Map<AspNetRoleView>(await AspNetRoleService.Get(aspNetRole.Id));

                if (toBeUpdated == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Entry not found");

                toBeUpdated.Name = aspNetRole.Name;


                var response = await AspNetRoleService.Update(Mapper.Map<IAspNetRoleDomain>(toBeUpdated));
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Wrong input.");
            }
        }
    }
}
