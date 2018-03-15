using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Survey.Repository.Common.IGenericRepository;
using Survey.DAL.Models;
using Survey.Repository.Common.IRepositories;

namespace Survey.MVC_WebApi.APIControllers
{
    [RoutePrefix("api/answer")]
    public class AnswerController : ApiController
    {
        private IAnswerRepository AnswerRepository;

        public AnswerController(IAnswerRepository _AnswerRepository)
        {
            this.AnswerRepository = _AnswerRepository;
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
                var entity =(await AnswerRepository.Get(id));
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Not found.");
            }
        }

        //[Route("getanswersbyquestion")]
        //[HttpGet]
        //public async Task<HttpResponseMessage> GetAnswersByQuestion(Guid questionId)
        //{
        //    try
        //    {
        //        var entity = (await AnswerRepository.GetAnswersByQuestion(questionId));
        //        return Request.CreateResponse(HttpStatusCode.OK, entity);
        //    }
        //    catch (Exception e)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Not found.");
        //    }
        //}

        [Route("add")]
        [HttpPost]
        public async Task<HttpResponseMessage> Add(Answer answer)
        {
            try
            {
                answer.Id = Guid.NewGuid();
                var entity = await AnswerRepository.Add((answer));
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
