using Survey.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Survey.Model.Common;
using Survey.Repository.Common.IGenericRepository;

namespace Survey.Service
{
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerRepository AnswerRepository;

        public AnswerService(IAnswerRepository _answerRepository)
        {
            this.AnswerRepository = _answerRepository;
        }

        public async Task<int> Add(IAnswerDomain entity)
        {
            var response = await AnswerRepository.Add(entity);
            return response;
        }

        public async Task<int> Delete(IAnswerDomain entity)
        {
            var response = await AnswerRepository.Delete(entity);
            return response;
        }

        public async Task<int> Delete(Guid id)
        {
            var response = await AnswerRepository.Delete(id);
            return response;
        }

        public async Task<IAnswerDomain> Get(Guid id)
        {
            var response = await AnswerRepository.Get(id);
            return response;
        }

        public async Task<IEnumerable<IAnswerDomain>> GetAll()
        {
            var response = await AnswerRepository.GetAll();
            return response;
        }

        //public async Task<IEnumerable<IAnswerDomain>> GetAnswersByQuestion(Guid questionId)
        //{
        //    var response = await AnswerRepository.GetAnswersByQuestion(questionId);
        //    return response;
        //}

        public async Task<int> Update(IAnswerDomain entity)
        {
            var response = await AnswerRepository.Update(entity);
            return response;
        }
    }
}
