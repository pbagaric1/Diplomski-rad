using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Survey.Repository.Common.IRepositories;
using Survey.DAL.Models;
using Survey.Business.Models.ViewModels;
using Survey.Business.Mapping;

namespace Survey.MVC_WebApi.ControllersAPI
{
    [System.Web.Http.RoutePrefix("api/poll")]
    public class PollController : ApiController
    {
        private IPollRepository PollRepository;
        private IQuestionRepository QuestionRepository;
        private IAspNetUserRepository AspNetUserRepository;

        public PollController(IPollRepository _PollRepository,
                              IQuestionRepository _QuestionRepository,
                              IAspNetUserRepository _AspNetUserRepository)
        {
            this.PollRepository = _PollRepository;
            this.QuestionRepository = _QuestionRepository;
            this.AspNetUserRepository = _AspNetUserRepository;
        }

        [System.Web.Http.Route("getall")]
        [System.Web.Http.HttpGet]
        public async Task<HttpResponseMessage> GetAll()
        {
            try
            {
                var entity = (await PollRepository.GetAll());
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Not found.");
            }
        }

        [System.Web.Http.Route("get")]
        [System.Web.Http.HttpGet]
        public async Task<HttpResponseMessage> Get(Guid id)
        {
            try
            {
                var entity = await PollRepository.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Not found.");
            }
        }

        [System.Web.Http.Route("getview")]
        [System.Web.Http.HttpGet]
        public async Task<HttpResponseMessage> GetView(Guid id)
        {
            try
            {
                var entity = await PollRepository.Get(id);

                List<QuestionView> questionViewList = new List<QuestionView>();
                var pollView = new PollView();

                foreach (Question question in entity.Questions)
                {
                    QuestionView questionView = new QuestionView();

                    if (question.QuestionChoices != null)
                    {
                        List<string> questionChoices = new List<string>();

                        foreach (QuestionChoice questionChoice in question.QuestionChoices)
                        {
                            questionChoices.Add(questionChoice.Name);
                        }

                        //questionViewList.Add(RadiogroupTypeMap.MapToDto(question, questionChoices));
                    }

                    if (question.QuestionGroup != null)
                    {
                        questionView.maximumRateDescription = question.QuestionGroup.maximumRateDescription;
                        questionView.minimumRateDescription = question.QuestionGroup.minimumRateDescription;
                    }

                    questionView.Title = question.Title;
                    questionView.Type = "asd";
                    questionView.isRequired = question.IsRequired;
                    //questionView.Choices = questionChoices;

                    questionViewList.Add(questionView);
                }

                pollView.UserId = entity.AspNetUserId;
                pollView.CreatedOn = entity.CreatedOn;
                pollView.Instructions = entity.Instructions;
                pollView.Name = entity.Name;
                pollView.Questions = questionViewList;

                return Request.CreateResponse(HttpStatusCode.OK, pollView);
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
        //        var entity = (await PollRepository.GetByUsername(username));
        //        return Request.CreateResponse(HttpStatusCode.OK, entity);
        //    }
        //    catch (Exception e)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Not found.");
        //    }
        //}

        [System.Web.Http.Authorize(Roles = "Admin, Ispitivac")]
        [System.Web.Http.Route("add")]
        [System.Web.Http.HttpPost]
        public async Task<HttpResponseMessage> Add(PollView receivedPoll)
        {
            try
            {
                if (receivedPoll.UserId == null)
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "User not found.");

                Poll poll = new Poll()
                {
                    Id = Guid.NewGuid(),
                    Name = receivedPoll.Name,
                    CreatedOn = receivedPoll.CreatedOn,
                    Instructions = receivedPoll.Instructions,
                    AspNetUserId = receivedPoll.UserId
                };

                await PollRepository.Add(poll);

                int i = 1;

                foreach (QuestionView receivedQuestion in receivedPoll.Questions)
                {
                    var questionId = Guid.NewGuid();
                    List<string> receivedQuestionChoices = receivedQuestion.Choices;
                    QuestionGroup questionGroup = new QuestionGroup();

                    List<QuestionChoice> questionChoices = new List<QuestionChoice>();

                    if (receivedQuestionChoices != null)
                    {
                        foreach (string item in receivedQuestionChoices)
                        {
                            QuestionChoice asdChoice = new QuestionChoice
                            {
                                Id = Guid.NewGuid(),
                                Name = item,
                                QuestionId = questionId,
                            };
                            questionChoices.Add(asdChoice);
                        }

                        questionGroup = null;
                    }

                    else if (receivedQuestion.minimumRateDescription != null && receivedQuestion.maximumRateDescription != null)
                    {
                        questionGroup.maximumRateDescription = receivedQuestion.maximumRateDescription;
                        questionGroup.minimumRateDescription = receivedQuestion.minimumRateDescription;
                    }

                    Question question = new Question
                    {
                        Id = questionId,
                        PollId = poll.Id,
                        InputTypeId = Guid.Empty,
                        QuestionOrder = i,
                        Title = receivedQuestion.Title,
                        IsRequired = receivedQuestion.isRequired,
                        QuestionGroup = questionGroup,
                        QuestionChoices = questionChoices
                    };

                    i++;

                    await QuestionRepository.Add(question);
                }

                return Request.CreateResponse(HttpStatusCode.OK, 0);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error adding poll");
            }
        }

        [System.Web.Http.Route("delete")]
        [System.Web.Http.HttpDelete]
        public async Task<HttpResponseMessage> Delete(Guid id)
        {
            try
            {
                var entity = await PollRepository.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error");
            }
        }

        [System.Web.Http.Route("edit")]
        [System.Web.Http.HttpPut]
        public async Task<HttpResponseMessage> Edit(Poll poll)
        {
            try
            {
                var toBeUpdated = await PollRepository.Get(poll.Id);

                if (toBeUpdated == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Entry not found");

                toBeUpdated.Name = poll.Name;

                var response = await PollRepository.Update((toBeUpdated));
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Wrong input.");
            }
        }
    }
}