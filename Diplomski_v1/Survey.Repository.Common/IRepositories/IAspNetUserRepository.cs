using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Survey.DAL.Models;

namespace Survey.Repository.Common.IRepositories
{
    public interface IAspNetUserRepository
    {
        Task<int> Add(AspNetUser entity);
        Task<int> Delete(string id);
        Task<int> Delete(AspNetUser entity);
        Task<int> Update(AspNetUser entity);
        Task<AspNetUser> Get(string id);
        Task<IEnumerable<AspNetUser>> GetAll();
        Task<bool> CheckIfUsernameTaken(AspNetUser user);
        Task<bool> CheckIfEmailTaken(AspNetUser user);
        Task<AspNetUser> GetByUsername(string username);
    }
}
