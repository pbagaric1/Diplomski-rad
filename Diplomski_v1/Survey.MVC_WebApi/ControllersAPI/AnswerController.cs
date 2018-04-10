using System;
using System.Collections.Generic;
using System.IdentityModel.Metadata;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.ApplicationInsights.Web;
using Newtonsoft.Json.Linq;
using Survey.Repository.Common.IGenericRepository;
using Survey.DAL.Models;
using Survey.Repository.Common.IRepositories;

namespace Survey.MVC_WebApi.ControllersAPI
{
    [RoutePrefix("api/answer")]
    public class AnswerController : ApiController
    {
        private IAnswerRepository AnswerRepository;
        private IQuestionRepository QuestionRepository;

        public AnswerController(IAnswerRepository _AnswerRepository, IQuestionRepository _QuestionRepository)
        {
            this.AnswerRepository = _AnswerRepository;
            this.QuestionRepository = _QuestionRepository;
        }

        [Route("getall")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetAll()
        {
            try
            {
                var entity = (await AnswerRepository.GetAll());
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
                var entity = (await AnswerRepository.Get(id));
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
                var entity = (await AnswerRepository.GetAnswersByQuestion(questionId));
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Not found.");
            }
        }

        [Route("getquestionresults")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetQuestionResults(Guid questionId)
        {
            try
            {
                var entity = await AnswerRepository.GetQuestionResults(questionId);
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Not found.");
            }
        }

        [Route("add")]
        [HttpPost]
        public async Task<HttpResponseMessage> Add(JObject receivedObject)
        {
            try
            {
                var results = receivedObject["results"].ToObject<Dictionary<string, object>>();
                var userId = receivedObject["userId"].ToString();
                var surveyId = receivedObject["surveyId"].ToString();
                Guid pollId = new Guid(surveyId);

                var questions = await QuestionRepository.GetQuestionsByPoll(pollId);

                int i = 0;
                foreach (string key in results.Keys)
                {
                    var item = questions.ElementAt(i);
                    

                    if (key == item.Name)
                    {
                        var answer = new Answer();
                        dynamic value = results[key];

                        if (item.QuestionType.Type == "checkbox")
                        {
                            int j = 0;
                            foreach (var asd in value)
                            {
                                answer = new Answer()
                                {
                                    AspNetUserId = userId,
                                    Id = Guid.NewGuid(),
                                    QuestionId = item.Id,
                                    Text = value[j].ToString()
                                };

                                var entity = await AnswerRepository.Add(answer);
                                j++;
                            }
                        }

                        else
                        {
                            answer = new Answer()
                            {
                                AspNetUserId = userId,
                                Id = Guid.NewGuid(),
                                QuestionId = item.Id,
                                Text = value.ToString()
                            };


                            var entity = await AnswerRepository.Add(answer);
                        }
                        
                    }

                    i++;
                }

                return Request.CreateResponse(HttpStatusCode.OK, 1);
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
                var entity = await AnswerRepository.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error");
            }
        }

        [Route("edit")]
        [HttpPut]
        public async Task<HttpResponseMessage> Edit(Answer answer)
        {
            try
            {
                var toBeUpdated = (await AnswerRepository.Get(answer.Id));

                if (toBeUpdated == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Entry not found");

                toBeUpdated.Text = answer.Text;

                var response = await AnswerRepository.Update((toBeUpdated));
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Wrong input.");
            }
        }
    }
}