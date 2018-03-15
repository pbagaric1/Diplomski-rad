using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Survey.DAL.Models;
using Survey.Repository.Common.IRepositories;

namespace Survey.MVC_WebApi.ControllersAPI
{
    [RoutePrefix("api/inputtype")]
    public class InputTypeController : ApiController
    {
        private IInputTypeRepository InputTypeRepository;

        public InputTypeController(IInputTypeRepository _InputTypeRepository)
        {
            this.InputTypeRepository = _InputTypeRepository;
        }

        [Route("getall")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetAll()
        {
            try
            {
                var entity = (await InputTypeRepository.GetAll());
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
                var entity = (await InputTypeRepository.Get(id));
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Not found.");
            }
        }

        //[Route("getInputTypesbyquestion")]
        //[HttpGet]
        //public async Task<HttpResponseMessage> GetInputTypesByQuestion(Guid questionId)
        //{
        //    try
        //    {
        //        var entity = (await InputTypeRepository.GetInputTypesByQuestion(questionId));
        //        return Request.CreateResponse(HttpStatusCode.OK, entity);
        //    }
        //    catch (Exception e)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Not found.");
        //    }
        //}

        [Route("add")]
        [HttpPost]
        public async Task<HttpResponseMessage> Add(QuestionType InputType)
        {
            try
            {
                var entity = await InputTypeRepository.Add((InputType));
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
                var entity = await InputTypeRepository.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error");
            }

        }

        [Route("edit")]
        [HttpPut]
        public async Task<HttpResponseMessage> Edit(QuestionType InputType)
        {
            try
            {
                var toBeUpdated = (await InputTypeRepository.Get(InputType.Id));

                if (toBeUpdated == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Entry not found");

                toBeUpdated.Type = InputType.Type;

                var response = await InputTypeRepository.Update((toBeUpdated));
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Wrong input.");
            }
        }
    }
}
