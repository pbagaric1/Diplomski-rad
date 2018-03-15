using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Survey.DAL.Models;

namespace Survey.Repository.Common.IRepositories
{
    public interface IQuestionRepository
    {
        Task<int> Add(Question entity);
        Task<int> Delete(Guid id);
        Task<int> Delete(Question entity);
        Task<int> Update(Question entity);
        Task<Question> Get(Guid id);
        Task<IEnumerable<Question>> GetAll();
        Task<IEnumerable<Question>> GetQuestionsByPoll(Guid pollId);
    }
}
