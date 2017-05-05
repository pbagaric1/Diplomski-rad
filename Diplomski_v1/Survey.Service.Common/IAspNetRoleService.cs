using Survey.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Service.Common
{
    public interface IAspNetRoleService
    {
        Task<int> Add(IAspNetRoleDomain entity);
        Task<int> Delete(string id);
        Task<int> Delete(IAspNetRoleDomain entity);
        Task<int> Update(IAspNetRoleDomain entity);
        Task<IAspNetRoleDomain> Get(string id);
        Task<IEnumerable<IAspNetRoleDomain>> GetAll();
    }
}
