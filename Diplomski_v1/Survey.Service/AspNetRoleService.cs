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
    public class AspNetRoleService : IAspNetRoleService
    {
        private readonly IAspNetRoleRepository AspNetRoleRepository;

        public AspNetRoleService(IAspNetRoleRepository _aspNetRoleRepository)
        {
            this.AspNetRoleRepository = _aspNetRoleRepository;
        }

        public async Task<int> Add(IAspNetRoleDomain entity)
        {
            var response = await AspNetRoleRepository.Add(entity);
            return response;
        }

        public async Task<int> Delete(IAspNetRoleDomain entity)
        {
            var response = await AspNetRoleRepository.Delete(entity);
            return response;
        }

        public async Task<int> Delete(string id)
        {
            var response = await AspNetRoleRepository.Delete(id);
            return response;
        }

        public async Task<IAspNetRoleDomain> Get(string id)
        {
            var response = await AspNetRoleRepository.Get(id);
            return response;
        }

        public async Task<IEnumerable<IAspNetRoleDomain>> GetAll()
        {
            var response = await AspNetRoleRepository.GetAll();
            return response;
        }

        public async Task<int> Update(IAspNetRoleDomain entity)
        {
            var response = await AspNetRoleRepository.Update(entity);
            return response;
        }
    }
}
