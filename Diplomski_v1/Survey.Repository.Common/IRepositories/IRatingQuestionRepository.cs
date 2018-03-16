using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Survey.DAL.Models;

namespace Survey.Repository.Common.IRepositories
{
    public interface IRatingQuestionRepository
    {
        Task<int> Add(RatingQuestion entity);
        Task<int> Delete(Guid id);
        Task<int> Delete(RatingQuestion entity);
        Task<int> Update(RatingQuestion entity);
        Task<RatingQuestion> Get(Guid id);
        Task<IEnumerable<RatingQuestion>> GetAll();
    }
}
