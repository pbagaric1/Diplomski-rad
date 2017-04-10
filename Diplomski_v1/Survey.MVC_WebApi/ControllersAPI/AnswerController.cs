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

namespace Survey.MVC_WebApi.APIControllers
{
    [RoutePrefix("api/answer")]
    public class AnswerController : ApiController
    {
        private IAnswerService AnswerService;

        public AnswerController(IAnswerService _answerService)
        {
            this.AnswerService = _answerService;
        }

        [Route("getall")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetAll()
        {
            try
            {
                var entity = Mapper.Map<IEnumerable<AnswerView>>(await AnswerService.GetAll());
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
                var entity = Mapper.Map<AnswerView>(await AnswerService.Get(id));
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Not found.");
            }
        }

        [Route("getanswersbyquestion")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetAnswersByQuestion(Guid questionId)
        {
            try
            {
                var entity = Mapper.Map<IEnumerable<AnswerView>>(await AnswerService.GetAnswersByQuestion(questionId));
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Not found.");
            }
        }

        [Route("add")]
        [HttpPost]
        public async Task<HttpResponseMessage> Add(AnswerView answer)
        {
            try
            {
                answer.Id = Guid.NewGuid();
                var entity = await AnswerService.Add(Mapper.Map<IAnswerDomain>(answer));
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
                var entity = await AnswerService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error");
            }

        }

        [Route("edit")]
        [HttpPut]
        public async Task<HttpResponseMessage> Edit(AnswerView answer)
        {
            try
            {
                var toBeUpdated = Mapper.Map<AnswerView>(await AnswerService.Get(answer.Id));

                if (toBeUpdated == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Entry not found");

                toBeUpdated.Name = answer.Name;

                var response = await AnswerService.Update(Mapper.Map<IAnswerDomain>(toBeUpdated));
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Wrong input.");
            }
        }
    }
}
