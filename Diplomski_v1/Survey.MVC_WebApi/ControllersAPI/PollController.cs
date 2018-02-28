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
    [RoutePrefix("api/poll")]
    public class PollController : ApiController
    {
        private IPollService PollService;
        private IQuestionService QuestionService;
        private IAnswerService AnswerService;

        public PollController(IPollService _pollService, IQuestionService _questionService, IAnswerService _answerService)
        {
            this.PollService = _pollService;
            this.QuestionService = _questionService;
            this.AnswerService = _answerService;
        }

        [Route("getall")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetAll()
        {
            try
            {
                var entity = Mapper.Map<IEnumerable<PollView>>(await PollService.GetAll());
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
                var entity = Mapper.Map<PollView>(await PollService.Get(id));
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Not found.");
            }
        }

        //[Route("getbyusername")]
        //[HttpGet]
        //public async Task<HttpResponseMessage> GetByUsername(string username)
        //{
        //    try
        //    {
        //        var entity = Mapper.Map<IEnumerable<PollView>>(await PollService.GetByUsername(username));
        //        return Request.CreateResponse(HttpStatusCode.OK, entity);
        //    }
        //    catch (Exception e)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Not found.");
        //    }
        //}

        //[Route("getbytype")]
        //[HttpGet]
        //public async Task<HttpResponseMessage> GetByType(Guid pollTypeId)
        //{
        //    try
        //    {
        //        var entity = Mapper.Map<IEnumerable<PollView>>(await PollService.GetPollsByType(pollTypeId));
        //        return Request.CreateResponse(HttpStatusCode.OK, entity);
        //    }
        //    catch (Exception e)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Not found.");
        //    }
        //}

        [Authorize(Roles="Admin, Ispitivac")]
        [Route("add")]
        [HttpPost]
        public async Task<HttpResponseMessage> Add(PollView poll)
        {
            try
            {
                poll.Id = Guid.NewGuid();
                poll.PollTypeId = new Guid("38396c4a-be53-4cbc-b685-354d046911ae");
                var entity = await PollService.Add(Mapper.Map<IPollDomain>(poll));
                foreach (QuestionView question in poll.Questions)
                {
                    question.Id = Guid.NewGuid();
                    question.PollId = poll.Id;
                    await QuestionService.Add(Mapper.Map<IQuestionDomain>(question));
                    foreach (AnswerView answer in question.Answers)
                    {
                        answer.Id = Guid.NewGuid();
                        answer.QuestionId = question.Id;
                        await AnswerService.Add(Mapper.Map<IAnswerDomain>(answer));
                    }
                    
                }
                
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error adding poll");
            }

        }

        [Route("delete")]
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(Guid id)
        {
            try
            {
                var entity = await PollService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error");
            }

        }

        [Route("edit")]
        [HttpPut]
        public async Task<HttpResponseMessage> Edit(PollView poll)
        {
            try
            {
                var toBeUpdated = Mapper.Map<PollView>(await PollService.Get(poll.Id));

                if (toBeUpdated == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Entry not found");

                toBeUpdated.Name = poll.Name;

                var response = await PollService.Update(Mapper.Map<IPollDomain>(toBeUpdated));
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Wrong input.");
            }
        }
    }
}
