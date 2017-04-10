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
    [RoutePrefix("api/polltype")]
    public class PollTypeController : ApiController
    {
        private IPollTypeService PollTypeService;

        public PollTypeController(IPollTypeService _pollTypeService)
        {
            this.PollTypeService = _pollTypeService;
        }

        [Route("getall")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetAll()
        {
            try
            {
                var entity = Mapper.Map<IEnumerable<PollTypeView>>(await PollTypeService.GetAll());
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Not found.");
            }
        }

        [Route("get")]
        [HttpGet]
        public async Task<HttpResponseMessage> Get(Guid id)
        {
            try
            {
                var entity = Mapper.Map<PollTypeView>(await PollTypeService.Get(id));
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Not found.");
            }
        }

        [Route("add")]
        [HttpPost]
        public async Task<HttpResponseMessage> Add(PollTypeView pollType)
        {
            try
            {
                pollType.Id = Guid.NewGuid();
                var entity = await PollTypeService.Add(Mapper.Map<IPollTypeDomain>(pollType));
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error");
            }

        }

        [Route("delete")]
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(Guid id)
        {
            try
            {
                var entity = await PollTypeService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error");
            }

        }

        [Route("edit")]
        [HttpPut]
        public async Task<HttpResponseMessage> Edit(PollTypeView pollType)
        {
            try
            {
                var toBeUpdated = Mapper.Map<PollTypeView>(await PollTypeService.Get(pollType.Id));

                if (toBeUpdated == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Entry not found");

                toBeUpdated.Name = pollType.Name;

                var response = await PollTypeService.Update(Mapper.Map<IPollTypeDomain>(toBeUpdated));
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Wrong input.");
            }
        }
    }
}
