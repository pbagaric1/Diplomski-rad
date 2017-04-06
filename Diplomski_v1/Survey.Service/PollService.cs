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

        public PollService(IPollRepository _pollRepository)
        {
            this.PollRepository = _pollRepository;
        }

        public async Task<int> Add(IPollDomain entity)
        {
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

        public async Task<IEnumerable<IPollDomain>> GetByUsername(string username)
        {
            var response = await PollRepository.GetByUsername(username);
            return response;
        }

        public async Task<IEnumerable<IPollDomain>> GetSurveysByType(Guid pollTypeId)
        {
            var response = await PollRepository.GetSurveysByType(pollTypeId);
            return response;
        }

        public async Task<int> Update(IPollDomain entity)
        {
            var response = await PollRepository.Update(entity);
            return response;
        }
    }
}
