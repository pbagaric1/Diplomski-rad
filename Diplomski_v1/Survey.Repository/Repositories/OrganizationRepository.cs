using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Survey.DAL.Models;
using Survey.Repository.Common.IRepositories;

namespace Survey.Repository.Repositories
{
    public class OrganizationRepository : IOrganizationRepository
    {
        public Task<int> Add(Organization entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(Organization entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Organization entity)
        {
            throw new NotImplementedException();
        }

        public Task<Organization> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Organization>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
