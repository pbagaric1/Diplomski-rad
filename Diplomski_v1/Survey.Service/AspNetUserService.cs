using Survey.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Survey.Model.Common;
using Survey.Repository.Common.IRepositories;

namespace Survey.Service
{
    public class AspNetUserService : IAspNetUserService
    {
        private readonly IAspNetUserRepository AspNetUserRepository;

        public AspNetUserService(IAspNetUserRepository _aspNetUserRepository)
        {
            this.AspNetUserRepository = _aspNetUserRepository;
        }


        public async Task<int> Add(IAspNetUserDomain entity)
        {
            var response = await AspNetUserRepository.Add(entity);
            return response;
        }

        public async Task<int> Delete(IAspNetUserDomain entity)
        {
            var response = await AspNetUserRepository.Delete(entity);
            return response;
        }

        public async Task<int> Delete(string id)
        {
            var response = await AspNetUserRepository.Delete(id);
            return response;
        }

        public async Task<IAspNetUserDomain> Get(string id)
        {
            var response = await AspNetUserRepository.Get(id);
            return response;
        }

        public async Task<IEnumerable<IAspNetUserDomain>> GetAll()
        {
            var response = await AspNetUserRepository.GetAll();
            return response;
        }

        public async Task<IAspNetUserDomain> GetByUsername(string username)
        {
            var response = await AspNetUserRepository.GetByUsername(username);
            return response;
        }

        public async Task<int> Update(IAspNetUserDomain entity)
        {
            var response = await AspNetUserRepository.Update(entity);
            return response;
        }
    }
}
