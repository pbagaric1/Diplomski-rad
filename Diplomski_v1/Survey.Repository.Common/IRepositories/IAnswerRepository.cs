using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Survey.Business.Models.ViewModels;
using Survey.DAL.Models;

namespace Survey.Repository.Common.IRepositories
{
    public interface IAnswerRepository
    {
        Task<int> Add(Answer entity);
        Task<int> Delete(Guid id);
        Task<int> Delete(Answer entity);
        Task<int> Update(Answer entity);
        Task<Answer> Get(Guid id);
        Task<IEnumerable<Answer>> GetAll();
        Task<IEnumerable<Answer>> GetAnswersByQuestion(Guid questionId);
        Task<IEnumerable<DataView>> GetQuestionResults(Guid questionId);
    }
}
