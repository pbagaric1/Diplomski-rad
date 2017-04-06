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
    public class AspNetUserLoginService : IAspNetUserLoginService
    {
        private readonly IAspNetUserLoginRepository AspNetUserLoginRepository;

        public AspNetUserLoginService(IAspNetUserLoginRepository _aspNetUserLoginRepository)
        {
            this.AspNetUserLoginRepository = _aspNetUserLoginRepository;
        }

        public async Task<int> Add(IAspNetUserLoginDomain entity)
        {
            var response = await AspNetUserLoginRepository.Add(entity);
            return response;
        }

        public async Task<int> Delete(IAspNetUserLoginDomain entity)
        {
            var response = await AspNetUserLoginRepository.Delete(entity);
            return response;
        }

        public async Task<int> Delete(string id)
        {
            var response = await AspNetUserLoginRepository.Delete(id);
            return response;
        }

        public async Task<IAspNetUserLoginDomain> Get(string id)
        {
            var response = await AspNetUserLoginRepository.Get(id);
            return response;
        }

        public async Task<IEnumerable<IAspNetUserLoginDomain>> GetAll()
        {
            var response = await AspNetUserLoginRepository.GetAll();
            return response;
        }

        public async Task<int> Update(IAspNetUserLoginDomain entity)
        {
            var response = await AspNetUserLoginRepository.Update(entity);
            return response;
        }
    }
}
