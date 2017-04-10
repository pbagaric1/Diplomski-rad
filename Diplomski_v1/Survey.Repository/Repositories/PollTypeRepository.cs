using Survey.Repository.Common.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Survey.Model.Common;
using Survey.Repository.Common.IGenericRepository;
using AutoMapper;
using Survey.DAL.Models;

namespace Survey.Repository.Repositories
{
    public class PollTypeRepository : IPollTypeRepository
    {

        private readonly IGenericRepository GenericRepository;

        public PollTypeRepository(IGenericRepository _genericRepository)
        {
            this.GenericRepository = _genericRepository;
        }


        public async Task<int> Add(IPollTypeDomain entity)
        {
            try
            {
                return await GenericRepository.Add(Mapper.Map<PollType>(entity));
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Delete(IPollTypeDomain entity)
        {
            try
            {
                return await GenericRepository.Delete(Mapper.Map<PollType>(entity));
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Delete(Guid id)
        {
            try
            {
                var entity = await GenericRepository.Get<PollType>(id);

                if (entity == null)
                    return 0;

                return await GenericRepository.Delete(entity);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IPollTypeDomain> Get(Guid id)
        {
            try
            {
                var response = Mapper.Map<IPollTypeDomain>(await GenericRepository.Get<PollType>(id));
                return response;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<IPollTypeDomain>> GetAll()
        {
            try
            {
                var response = Mapper.Map<IEnumerable<IPollTypeDomain>>(await GenericRepository.GetAll<PollType>());
                return response;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Update(IPollTypeDomain entity)
        {
            try
            {
                return await GenericRepository.Update(Mapper.Map<PollType>(entity));
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
