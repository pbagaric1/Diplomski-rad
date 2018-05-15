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
using Survey.Business.Mapping.DtoToView;

namespace Survey.MVC_WebApi.ControllersAPI
{
    [System.Web.Http.RoutePrefix("api/poll")]
    public class PollController : ApiController
    {
        private IPollRepository PollRepository;
        private IAspNetUserRepository AspNetUserRepository;

        public PollController(IPollRepository _PollRepository, IAspNetUserRepository _AspNetUserRepository)
        {
            this.PollRepository = _PollRepository;
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

        [System.Web.Http.Route("getallview")]
        [System.Web.Http.HttpGet]
        public async Task<HttpResponseMessage> GetAllView()
        {
            try
            {
                var entity = (await PollRepository.GetAllView());
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Not found.");
            }
        }

        [System.Web.Http.Authorize(Roles = "Ispitanik")]
        [System.Web.Http.Route("getnumberofpolls")]
        [System.Web.Http.HttpGet]
        public async Task<HttpResponseMessage> GetNumberOfPolls(int pageIndex, int pageSize)
        {
            try
            {
                var entity = await PollRepository.GetNumberOfPolls(pageIndex, pageSize);
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
                var entity = await PollRepository.GetView(id);
                
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Not found.");
            }
        }

        [System.Web.Http.Authorize(Roles = "Admin, Ispitivac")]
        [Route("getbyusername")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetByUsername(string userId)
        {
            try
            {
                var entity = (await PollRepository.GetByUsername(userId));
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Not found.");
            }
        }

        [System.Web.Http.Authorize(Roles = "Ispitivac")]
        [System.Web.Http.Route("add")]
        [System.Web.Http.HttpPost]
        public async Task<HttpResponseMessage> Add(ReceivedPollView receivedPoll)
        {
            try
            {
                if (receivedPoll.UserId == null)
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "User not found.");

                int i = 1;

                var questionList = new List<Question>();

                foreach (var receivedQuestion in receivedPoll.Questions)
                {
                    if (receivedQuestion.type == "rating")
                    questionList.Add(RatingMap.MapToDto(receivedQuestion, i));
                    
                    else if (receivedQuestion.type == "checkbox" || receivedQuestion.type == "radiogroup")
                        questionList.Add(CheckboxRadiogroupMap.MapToDto(receivedQuestion, i));

                    else
                        questionList.Add(TextMap.MapToDto(receivedQuestion, i));
                    i++;
                }


                Poll poll = new Poll()
                {
                    Id = Guid.NewGuid(),
                    Name = receivedPoll.Name,
                    CreatedOn = receivedPoll.CreatedOn,
                    Instructions = receivedPoll.Instructions,
                    AspNetUserId = receivedPoll.UserId,
                    Questions = questionList

                };

                await PollRepository.Add(poll);

                return Request.CreateResponse(HttpStatusCode.OK, 0);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error adding poll");
            }
        }
        [System.Web.Http.Authorize(Roles = "Admin, Ispitivac")]
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
        [System.Web.Http.Authorize(Roles = "Ispitivac")] 
        [System.Web.Http.Route("edit")]
        [System.Web.Http.HttpPut]
        public async Task<HttpResponseMessage> Edit(PollView poll)
        {
            try
            {
                var toBeUpdated = await PollRepository.Get(poll.Id);

                if (toBeUpdated == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Entry not found");

              toBeUpdated.Visibility = poll.visibility;
              toBeUpdated.ActivityEndTime = poll.activityEndTime;
              toBeUpdated.ActivityStartTime = poll.activityStartTime;
              toBeUpdated.CreatedOn = poll.createdOn;
              toBeUpdated.AspNetUserId = poll.userId;
              toBeUpdated.Name = poll.title;

                var response = await PollRepository.Update(toBeUpdated);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Wrong input.");
            }
        }
    }
}
