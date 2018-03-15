using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Survey.DAL.Models;

namespace Survey.Repository.Common.IRepositories
{
    public interface IPollRepository
    {
        Task<int> Add(Poll entity);
        Task<int> Delete(Guid id);
        Task<int> Delete(Poll entity);
        Task<int> Update(Poll entity);
        Task<Poll> Get(Guid id);
        Task<IEnumerable<Poll>> GetAll();
        //Task<IEnumerable<Poll>> GetPollsByType(Guid pollTypeId);
        //Task<IEnumerable<Poll>> GetByUsername(string username);
    }
}
