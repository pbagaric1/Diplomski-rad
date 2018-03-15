using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Survey.DAL.Models;
using Survey.Repository.Common.IRepositories;

namespace Survey.Repository.Repositories
{
    public class UserPollRepository : IUserPollRepository
    {
        public Task<int> Add(UserPoll entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(UserPoll entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(UserPoll entity)
        {
            throw new NotImplementedException();
        }

        public Task<UserPoll> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserPoll>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
