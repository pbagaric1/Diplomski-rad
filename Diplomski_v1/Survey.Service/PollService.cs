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
    public class PollService : IPollService
    {
        private readonly IPollRepository PollRepository;
        private readonly IAspNetUserRepository AspNetUserRepository;

        public PollService(IPollRepository _pollRepository, IAspNetUserRepository _aspNetUserRepository)
        {
            this.PollRepository = _pollRepository;
            this.AspNetUserRepository = _aspNetUserRepository;
        }

        public async Task<int> Add(IPollDomain entity)
        {
            var user = await AspNetUserRepository.GetByUsername(entity.UserId);
            var userId = user.Id;

            entity.UserId = userId;

            var response = await PollRepository.Add(entity);
            return response;
        }

        public async Task<int> Delete(IPollDomain entity)
        {
            var response = await PollRepository.Delete(entity);
            return response;
        }

        public async Task<int> Delete(Guid id)
        {
            var response = await PollRepository.Delete(id);
            return response;
        }

        public async Task<IPollDomain> Get(Guid id)
        {
            var response = await PollRepository.Get(id);
            return response;
        }

        public async Task<IEnumerable<IPollDomain>> GetAll()
        {
            var response = await PollRepository.GetAll();
            return response;
        }

        //public async Task<IEnumerable<IPollDomain>> GetByUsername(string username)
        //{
        //    var response = await PollRepository.GetByUsername(username);
        //    return response;
        //}

        //public async Task<IEnumerable<IPollDomain>> GetPollsByType(Guid pollTypeId)
        //{
        //    var response = await PollRepository.GetPollsByType(pollTypeId);
        //    return response;
        //}

        public async Task<int> Update(IPollDomain entity)
        {
            var response = await PollRepository.Update(entity);
            return response;
        }
    }
}
