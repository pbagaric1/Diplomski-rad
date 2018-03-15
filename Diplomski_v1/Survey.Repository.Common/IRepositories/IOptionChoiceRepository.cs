using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Survey.DAL.Models;

namespace Survey.Repository.Common.IRepositories
{
    public interface IQuestionChoiceRepository
    {
        Task<int> Add(QuestionChoice entity);
        Task<int> Delete(Guid id);
        Task<int> Delete(QuestionChoice entity);
        Task<int> Update(QuestionChoice entity);
        Task<QuestionChoice> Get(Guid id);
        Task<IEnumerable<QuestionChoice>> GetAll();
    }
}
