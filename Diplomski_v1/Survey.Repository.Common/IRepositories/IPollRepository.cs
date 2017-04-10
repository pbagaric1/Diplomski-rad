using Survey.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Repository.Common.IRepositories
{
    public interface IPollRepository
    {
        Task<int> Add(IPollDomain entity);
        Task<int> Delete(Guid id);
        Task<int> Delete(IPollDomain entity);
        Task<int> Update(IPollDomain entity);
        Task<IPollDomain> Get(Guid id);
        Task<IEnumerable<IPollDomain>> GetAll();
        Task<IEnumerable<IPollDomain>> GetPollsByType(Guid pollTypeId);
        Task<IEnumerable<IPollDomain>> GetByUsername(string username);
    }
}
