using Survey.Repository.Common.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Survey.Model.Common;
using Survey.Repository.Common.IGenericRepository;
using AutoMapper;
using Survey.Model;
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

        public async Task<int> Add(IAspNetRoleDomain entity)
        {
            try
            {
                return await GenericRepository.Add(Mapper.Map<AspNetRole>(entity));
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Delete(IAspNetRoleDomain entity)
        {
            try
            {
                return await GenericRepository.Delete(Mapper.Map<AspNetRole>(entity));
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

        public async Task<IAspNetRoleDomain> Get(string id)
        {
            try
            {
                var response = Mapper.Map<AspNetRoleDomain>(await GenericRepository.Get<AspNetRole>(id));
                return response;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<IAspNetRoleDomain>> GetAll()
        {
            try
            {
                var response = Mapper.Map<IEnumerable<IAspNetRoleDomain>>(await GenericRepository.GetAll<AspNetRole>());
                return response;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Update(IAspNetRoleDomain entity)
        {
            try
            {
                return await GenericRepository.Update(Mapper.Map<AspNetRole>(entity));
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
