using Survey.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Repository.Common.IGenericRepository
{
    public interface IAnswerRepository
    {
        Task<int> Add(IAnswerDomain entity);
        Task<int> Delete(Guid id);
        Task<int> Delete(IAnswerDomain entity);
        Task<int> Update(IAnswerDomain entity);
        Task<IAnswerDomain> Get(Guid id);
        Task<IEnumerable<IAnswerDomain>> GetAll();
        //Task<IEnumerable<IAnswerDomain>> GetAnswersByQuestion(Guid questionId);
    }
}
