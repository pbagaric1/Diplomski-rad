using Survey.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Service.Common
{
    public interface IAspNetUserLoginService
    {
        Task<int> Add(IAspNetUserLoginDomain entity);
        Task<int> Delete(string id);
        Task<int> Delete(IAspNetUserLoginDomain entity);
        Task<int> Update(IAspNetUserLoginDomain entity);
        Task<IAspNetUserLoginDomain> Get(string id);
        Task<IEnumerable<IAspNetUserLoginDomain>> GetAll();
    }
}
