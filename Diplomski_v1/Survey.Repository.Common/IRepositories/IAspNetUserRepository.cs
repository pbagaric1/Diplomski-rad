using Survey.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Repository.Common.IRepositories
{
    public interface IAspNetUserRepository
    {
        Task<int> Add(IAspNetUserDomain entity);
        Task<int> Delete(string id);
        Task<int> Delete(IAspNetUserDomain entity);
        Task<int> Update(IAspNetUserDomain entity);
        Task<IAspNetUserDomain> Get(string id);
        Task<IEnumerable<IAspNetUserDomain>> GetAll();
        Task<IAspNetUserDomain> GetByUsername(string username);
    }
}
