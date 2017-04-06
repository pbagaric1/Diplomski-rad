using Survey.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Survey.Model.Common;
using Survey.Repository.Common.IRepositories;

namespace Survey.Service
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository QuestionRepository;

        public QuestionService(IQuestionRepository _questionRepository)
        {
            this.QuestionRepository = _questionRepository;
        }

        public async Task<int> Add(IQuestionDomain entity)
        {
            var response = await QuestionRepository.Add(entity);
            return response;
        }

        public async Task<int> Delete(IQuestionDomain entity)
        {
            var response = await QuestionRepository.Delete(entity);
            return response;
        }

        public async Task<int> Delete(Guid id)
        {
            var response = await QuestionRepository.Delete(id);
            return response;
        }

        public async Task<IQuestionDomain> Get(Guid id)
        {
            var response = await QuestionRepository.Get(id);
            return response;
        }

        public async Task<IEnumerable<IQuestionDomain>> GetAll()
        {
            var response = await QuestionRepository.GetAll();
            return response;
        }

        public async Task<IEnumerable<IQuestionDomain>> GetQuestionsBySurvey(Guid pollId)
        {
            var response = await QuestionRepository.GetQuestionsBySurvey(pollId);
            return response;
        }

        public async Task<int> Update(IQuestionDomain entity)
        {
            var response = await QuestionRepository.Update(entity);
            return response;
        }
    }
}
