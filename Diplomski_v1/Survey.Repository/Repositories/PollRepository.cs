using Survey.Repository.Common.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


        public async Task<int> Add(Poll entity)
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

        public async Task<int> Delete(Poll entity)
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

        public async Task<int> Delete(Guid id)
        {
            try
            {
                var entity = await GenericRepository.Get<Poll>(id);

                if (entity == null)
                    return 0;

                return await GenericRepository.Delete(entity);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Poll> Get(Guid id)
        {
            try
            {
                var response = (await GenericRepository.Get<Poll>(id));

                return response;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Poll>> GetAll()
        {
            try
            {
                var response = (await GenericRepository.GetAll<Poll>());
                return response;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public async Task<IEnumerable<Poll>> GetByUsername(string username)
        //{
        //    try
        //    {
        //        var response = Mapper.Map<IEnumerable<Poll>>(await GenericRepository
        //            .GetQueryable<Poll>().Where(x => x.AspNetUser.UserName == username)
        //            .ToListAsync());
        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public async Task<IEnumerable<Poll>> GetPollsByType(Guid pollTypeId)
        //{
        //    try
        //    {
        //        var response = Mapper.Map<IEnumerable<Poll>>(await GenericRepository
        //            .GetQueryable<Poll>().Where(x => x.PollTypeId == pollTypeId)
        //            .ToListAsync());
        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public async Task<int> Update(Poll entity)
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
