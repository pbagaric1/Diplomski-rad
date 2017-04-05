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
using System.Data.Entity;

namespace Survey.Repository.Repositories
{
    public class PollRepository : IPollRepository
    {

        private readonly IGenericRepository GenericRepository;

        public PollRepository(IGenericRepository _genericRepository)
        {
            this.GenericRepository = _genericRepository;
        }


        public async Task<int> Add(IPollDomain entity)
        {
            try
            {
                return await GenericRepository.Add(Mapper.Map<Poll>(entity));
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Delete(IPollDomain entity)
        {
            try
            {
                return await GenericRepository.Delete(Mapper.Map<Poll>(entity));
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
                var entity = GenericRepository.Get<Poll>(id);

                if (entity == null)
                    return 0;

                return await GenericRepository.Delete(entity);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IPollDomain> Get(Guid id)
        {
            try
            {
                var response = Mapper.Map<IPollDomain>(await GenericRepository.Get<Poll>(id));
                return response;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<IPollDomain>> GetAll()
        {
            try
            {
                var response = Mapper.Map<IEnumerable<IPollDomain>>(await GenericRepository.GetAll<Poll>());
                return response;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<IPollDomain>> GetByUsername(string username)
        {
            try
            {
                var response = Mapper.Map<IEnumerable<IPollDomain>>(await GenericRepository
                    .GetQueryable<Poll>().Where(x => x.AspNetUser.UserName == username)
                    .ToListAsync());
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<IPollDomain>> GetSurveysByType(Guid pollTypeId)
        {
            try
            {
                var response = Mapper.Map<IEnumerable<IPollDomain>>(await GenericRepository
                    .GetQueryable<Poll>().Where(x => x.PollTypeId == pollTypeId)
                    .ToListAsync());
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Update(IPollDomain entity)
        {
            try
            {
                return await GenericRepository.Update(Mapper.Map<Poll>(entity));
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
