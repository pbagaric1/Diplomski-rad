using Survey.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Service.Common
{
    public interface IQuestionService
    {
        Task<int> Add(IQuestionDomain entity);
        Task<int> Delete(Guid id);
        Task<int> Delete(IQuestionDomain entity);
        Task<int> Update(IQuestionDomain entity);
        Task<IQuestionDomain> Get(Guid id);
        Task<IEnumerable<IQuestionDomain>> GetAll();
        Task<IEnumerable<IQuestionDomain>> GetQuestionsByPoll(Guid pollId);
    }
}
