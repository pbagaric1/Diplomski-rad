using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Survey.DAL.Models;
using Survey.Repository.Common.IRepositories;

namespace Survey.Repository.Repositories
{
    public class QuestionOptionRepository : IQuestionOptionRepository
    {
        public Task<int> Add(QuestionOption entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(QuestionOption entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(QuestionOption entity)
        {
            throw new NotImplementedException();
        }

        public Task<QuestionOption> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<QuestionOption>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
