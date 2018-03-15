using System.Collections.Generic;
using System.Threading.Tasks;
using Survey.DAL.Models;

namespace Survey.Repository.Common.IRepositories
{
    public interface IAspNetUserLoginRepository
    {
        Task<int> Add(AspNetUserLogin entity);
        Task<int> Delete(string id);
        Task<int> Delete(AspNetUserLogin entity);
        Task<int> Update(AspNetUserLogin entity);
        Task<AspNetUserLogin> Get(string id);
        Task<IEnumerable<AspNetUserLogin>> GetAll();
    }
}
