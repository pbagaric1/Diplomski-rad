using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Survey.Repository.Common.IRepositories;
using Survey.DAL.Models;

namespace Survey.MVC_WebApi.ControllersAPI
{
    [RoutePrefix("api/question")]
    public class QuestionController : ApiController
    {
        private IQuestionRepository QuestionRepository;

        public QuestionController(IQuestionRepository _QuestionRepository)
        {
            this.QuestionRepository = _QuestionRepository;
        }

        [Route("getall")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetAll()
        {
            try
            {
                var entity = (await QuestionRepository.GetAll());
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
                var entity = Mapper.Map<Question>(await QuestionRepository.Get(id));
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Not found.");
            }
        }

        [Route("getbysurvey")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetQuestionsBySurvey(Guid pollId)
        {
            try
            {
                var entity = (await QuestionRepository.GetQuestionsByPoll(pollId));
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Not found.");
            }
        }

        [Route("add")]
        [HttpPost]
        public async Task<HttpResponseMessage> Add(Question poll)
        {
            try
            {
                poll.Id = Guid.NewGuid();
                var entity = await QuestionRepository.Add((poll));
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
                var entity = await QuestionRepository.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error");
            }
        }

        [Route("edit")]
        [HttpPut]
        public async Task<HttpResponseMessage> Edit(Question question)
        {
            try
            {
                var toBeUpdated = (await QuestionRepository.Get(question.Id));

                if (toBeUpdated == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Entry not found");

                toBeUpdated.Name = question.Name;

                var response = await QuestionRepository.Update((toBeUpdated));
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Wrong input.");
            }
        }
    }
}