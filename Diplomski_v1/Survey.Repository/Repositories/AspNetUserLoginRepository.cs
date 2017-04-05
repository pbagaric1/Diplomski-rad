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
    public class AspNetUserLoginRepository : IAspNetUserLoginRepository
    {

        private readonly IGenericRepository GenericRepository;

        public AspNetUserLoginRepository(IGenericRepository _genericRepository)
        {
            this.GenericRepository = _genericRepository;
        }


        public async Task<int> Add(IAspNetUserLoginDomain entity)
        {
            try
            {
                return await GenericRepository.Add(Mapper.Map<AspNetUserLogin>(entity));
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Delete(IAspNetUserLoginDomain entity)
        {
            try
            {
                return await GenericRepository.Delete(Mapper.Map<AspNetUserLogin>(entity));
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Delete(string id)
        {
            try
            {
                var entity = GenericRepository.Get<AspNetUserLogin>(id);

                if (entity == null)
                    return 0;

                return await GenericRepository.Delete(entity);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IAspNetUserLoginDomain> Get(string id)
        {
            try
            {
                var response = Mapper.Map<IAspNetUserLoginDomain>(await GenericRepository.Get<AspNetUserLogin>(id));
                return response;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<IAspNetUserLoginDomain>> GetAll()
        {
            try
            {
                var response = Mapper.Map<IEnumerable<IAspNetUserLoginDomain>>(await GenericRepository.GetAll<AspNetUserLogin>());
                return response;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Update(IAspNetUserLoginDomain entity)
        {
            try
            {
                return await GenericRepository.Update(Mapper.Map<AspNetUserLogin>(entity));
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
