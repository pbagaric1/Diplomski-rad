using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Survey.DAL.Models;

namespace Survey.Repository.Common.IRepositories
{
    public interface IInputTypeRepository
    {
        Task<int> Add(QuestionType entity);
        Task<int> Delete(Guid id);
        Task<int> Delete(QuestionType entity);
        Task<int> Update(QuestionType entity);
        Task<QuestionType> Get(Guid id);
        Task<IEnumerable<QuestionType>> GetAll();
    }
}
