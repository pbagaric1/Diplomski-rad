using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Survey.DAL.Models;

namespace Survey.Repository.Common.IRepositories
{
    public interface IOrganizationRepository
    {
        Task<int> Add(Organization entity);
        Task<int> Delete(Guid id);
        Task<int> Delete(Organization entity);
        Task<int> Update(Organization entity);
        Task<Organization> Get(Guid id);
        Task<IEnumerable<Organization>> GetAll();
    }
}
