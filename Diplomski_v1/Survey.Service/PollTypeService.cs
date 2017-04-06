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
    public class PollTypeService : IPollTypeService
    {
        private readonly IPollTypeRepository PollTypeRepository;

        public PollTypeService(IPollTypeRepository _pollTypeRepository)
        {
            this.PollTypeRepository = _pollTypeRepository;
        }

        public async Task<int> Add(IPollTypeDomain entity)
        {
            var response = await PollTypeRepository.Add(entity);
            return response;
        }

        public async Task<int> Delete(IPollTypeDomain entity)
        {
            var response = await PollTypeRepository.Delete(entity);
            return response;
        }

        public async Task<int> Delete(Guid id)
        {
            var response = await PollTypeRepository.Delete(id);
            return response;
        }

        public async Task<IPollTypeDomain> Get(Guid id)
        {
            var response = await PollTypeRepository.Get(id);
            return response;
        }

        public async Task<IEnumerable<IPollTypeDomain>> GetAll()
        {
            var response = await PollTypeRepository.GetAll();
            return response;
        }

        public async Task<int> Update(IPollTypeDomain entity)
        {
            var response = await PollTypeRepository.Update(entity);
            return response;
        }
    }
}
