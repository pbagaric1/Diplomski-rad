using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Survey.DAL.Models;

namespace Survey.Repository.Common.IRepositories
{
    public interface IQuestionOptionRepository
    {
        Task<int> Add(QuestionOption entity);
        Task<int> Delete(Guid id);
        Task<int> Delete(QuestionOption entity);
        Task<int> Update(QuestionOption entity);
        Task<QuestionOption> Get(Guid id);
        Task<IEnumerable<QuestionOption>> GetAll();
    }
}
