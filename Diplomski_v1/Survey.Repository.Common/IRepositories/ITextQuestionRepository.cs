using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Survey.DAL.Models;

namespace Survey.Repository.Common.IRepositories
{
    public interface ITextQuestionRepository
    {
        Task<int> Add(TextQuestion entity);
        Task<int> Delete(Guid id);
        Task<int> Delete(TextQuestion entity);
        Task<int> Update(TextQuestion entity);
        Task<TextQuestion> Get(Guid id);
        Task<IEnumerable<TextQuestion>> GetAll();
        //Task<IEnumerable<TextQuestion>> GetTextQuestionsByPoll(Guid pollId);
    }
}
