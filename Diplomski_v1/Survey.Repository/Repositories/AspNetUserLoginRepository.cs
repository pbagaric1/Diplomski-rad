using Survey.Repository.Common.IRepositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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


        public async Task<int> Add(AspNetUserLogin entity)
        {
            try
            {
                return await GenericRepository.Add((entity));
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Delete(AspNetUserLogin entity)
        {
            try
            {
                return await GenericRepository.Delete((entity));
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
                var entity = await GenericRepository.Get<AspNetUserLogin>(id);

                if (entity == null)
                    return 0;

                return await GenericRepository.Delete(entity);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AspNetUserLogin> Get(string id)
        {
            try
            {
                var response = (await GenericRepository.Get<AspNetUserLogin>(id));
                return response;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<AspNetUserLogin>> GetAll()
        {
            try
            {
                var response = (await GenericRepository.GetAll<AspNetUserLogin>());
                return response;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Update(AspNetUserLogin entity)
        {
            try
            {
                return await GenericRepository.Update((entity));
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
