using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Survey.DAL.Models;

namespace Survey.Repository.Common.IRepositories
{
    public interface IUserPollRepository
    {
        Task<int> Add(UserPoll entity);
        Task<int> Delete(Guid id);
        Task<int> Delete(UserPoll entity);
        Task<int> Update(UserPoll entity);
        Task<UserPoll> Get(Guid id);
        Task<IEnumerable<UserPoll>> GetAll();
    }
}
