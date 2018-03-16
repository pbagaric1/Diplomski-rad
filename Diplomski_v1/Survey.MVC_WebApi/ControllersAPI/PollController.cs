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
        private ITextQuestionRepository QuestionRepository;
        private IAspNetUserRepository AspNetUserRepository;
        private ITextQuestionRepository TextQuestionRepository;
        private IRadiogroupQuestionRepository RadiogroupQuestionRepository;
        private ICheckboxQuestionRepository CheckboxQuestionRepository;
        private IRatingQuestionRepository RatingQuestionRepository;

        public PollController(IPollRepository _PollRepository, ITextQuestionRepository _TextQuestionRepository,
                              IRadiogroupQuestionRepository _RadioGroupQuestionRepository, IRatingQuestionRepository _RatingQuestionRepository,
                              IAspNetUserRepository _AspNetUserRepository, ICheckboxQuestionRepository _CheckboxQuestionRepository)
        {
            this.PollRepository = _PollRepository;
            this.TextQuestionRepository = _TextQuestionRepository;
            this.AspNetUserRepository = _AspNetUserRepository;
            this.RadiogroupQuestionRepository = _RadioGroupQuestionRepository;
            this.CheckboxQuestionRepository = _CheckboxQuestionRepository;
            this.RatingQuestionRepository = _RatingQuestionRepository;

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

                var questionView = new QuestionView()
                {
                    TextQuestions = entity.TextQuestions,
                    CheckboxQuestions = entity.CheckboxQuestions,
                    RatingQuestions = entity.RatingQuestions,
                    RadiogroupQuestions = entity.RadiogroupQuestions
                };

                var questionList = new List<ReceivedQuestionView>();
                var questionViewList = new List<QuestionView>();
                questionViewList.Add(questionView);

                var pageView = new PageView()
                {
                    Questions = questionViewList
                };

                var pageViewList = new List<PageView>();

                pageViewList.Add(pageView);

                var pollView = new PollView()
                {
                    UserId = entity.AspNetUserId,
                    CreatedOn = entity.CreatedOn,
                    Instructions = entity.Instructions,
                    Name = entity.Name,
                    Pages = pageViewList
                };

                //pollView.UserId = entity.AspNetUserId;
                //pollView.CreatedOn = entity.CreatedOn;
                //pollView.Instructions = entity.Instructions;
                //pollView.Name = entity.Name;
                //pollView.Questions = questionViewList;

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
        public async Task<HttpResponseMessage> Add(ReceivedPollView receivedPoll)
        {
            try
            {
                if (receivedPoll.UserId == null)
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "User not found.");

               

                int i = 1;
                List<CheckboxQuestion> checkboxQuestions = new List<CheckboxQuestion>();
                List<RatingQuestion> ratingQuestions = new List<RatingQuestion>();
                List<RadiogroupQuestion> radiogroupQuestions = new List<RadiogroupQuestion>();
                List<TextQuestion> textQuestions = new List<TextQuestion>();

                foreach (var receivedQuestion in receivedPoll.Questions)
                {
                    switch (receivedQuestion.Type)
                    {
                        case "Text":
                            textQuestions.Add(TextMap.MapToDto(receivedQuestion, i));
                            //await TextQuestionRepository.Add(TextMap.MapToDto(receivedQuestion, i));
                            break;

                        case "Radiogroup":
                            radiogroupQuestions.Add(RadiogroupMap.MapToDto(receivedQuestion, i));
                            break;

                        case "Checkbox":
                            checkboxQuestions.Add(CheckboxMap.MapToDto(receivedQuestion, i));
                            break;

                        case "Rating":
                            ratingQuestions.Add(RatingMap.MapToDto(receivedQuestion, i));
                            break;
                    }

                    i++;
                }

                Poll poll = new Poll()
                {
                    Id = Guid.NewGuid(),
                    Name = receivedPoll.Name,
                    CreatedOn = receivedPoll.CreatedOn,
                    Instructions = receivedPoll.Instructions,
                    AspNetUserId = receivedPoll.UserId,
                    TextQuestions = textQuestions,
                    CheckboxQuestions = checkboxQuestions,
                    RadiogroupQuestions = radiogroupQuestions,
                    RatingQuestions = ratingQuestions

                };

                await PollRepository.Add(poll);

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