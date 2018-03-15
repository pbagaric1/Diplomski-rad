using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Survey.DAL.Models;
using Survey.Repository.Common.IRepositories;

namespace Survey.Repository.Repositories
{
    public class QuestionChoiceRepository : IQuestionChoiceRepository
    {
        public Task<int> Add(QuestionChoice entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(QuestionChoice entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(QuestionChoice entity)
        {
            throw new NotImplementedException();
        }

        public Task<QuestionChoice> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<QuestionChoice>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
