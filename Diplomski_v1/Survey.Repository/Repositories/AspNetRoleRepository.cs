using Survey.Repository.Common.IRepositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Survey.Repository.Common.IGenericRepository;
using Survey.DAL.Models;

namespace Survey.Repository.Repositories
{
    public class AspNetRoleRepository : IAspNetRoleRepository
    {
        private readonly IGenericRepository GenericRepository;

        public AspNetRoleRepository(IGenericRepository _genericRepository)
        {
            this.GenericRepository = _genericRepository;
        }

        public async Task<int> Add(AspNetRole entity)
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

        public async Task<int> Delete(AspNetRole entity)
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
                var entity = await GenericRepository.Get<AspNetRole>(id);

                if (entity == null)
                    return 0;

                return await GenericRepository.Delete(entity);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AspNetRole> Get(string id)
        {
            try
            {
                var response = (await GenericRepository.Get<AspNetRole>(id));
                return response;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<AspNetRole>> GetAll()
        {
            try
            {
                var response = (await GenericRepository.GetAll<AspNetRole>());
                return response;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Update(AspNetRole entity)
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
