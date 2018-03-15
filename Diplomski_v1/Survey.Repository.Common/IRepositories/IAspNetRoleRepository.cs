using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Survey.DAL.Models;

namespace Survey.Repository.Common.IRepositories
{
    public interface IAspNetRoleRepository
    {
        Task<int> Add(AspNetRole entity);
        Task<int> Delete(string id);
        Task<int> Delete(AspNetRole entity);
        Task<int> Update(AspNetRole entity);
        Task<AspNetRole> Get(string id);
        Task<IEnumerable<AspNetRole>> GetAll();
    }
}
