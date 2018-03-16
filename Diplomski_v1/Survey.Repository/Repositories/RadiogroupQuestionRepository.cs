using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Survey.DAL.Models;
using Survey.Repository.Common.IGenericRepository;
using Survey.Repository.Common.IRepositories;

namespace Survey.Repository.Repositories
{
    public class RadiogroupQuestionRepository : IRadiogroupQuestionRepository
    {

        private readonly IGenericRepository GenericRepository;

        public RadiogroupQuestionRepository(IGenericRepository _genericRepository)
        {
            this.GenericRepository = _genericRepository;
        }


        public async Task<int> Add(RadiogroupQuestion entity)
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

        public async Task<int> Delete(RadiogroupQuestion entity)
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
                var entity = await GenericRepository.Get<RadiogroupQuestion>(id);

                if (entity == null)
                    return 0;

                return await GenericRepository.Delete(entity);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<RadiogroupQuestion> Get(Guid id)
        {
            try
            {
                var response = (await GenericRepository.Get<RadiogroupQuestion>(id));
                return response;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<RadiogroupQuestion>> GetAll()
        {
            try
            {
                var response = (await GenericRepository.GetAll<RadiogroupQuestion>());
                return response;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<RadiogroupQuestion>> GetRadiogroupQuestionsByPoll(Guid pollId)
        {
            try
            {
                var response = Mapper.Map<IEnumerable<RadiogroupQuestion>>(await GenericRepository
                                                                               .GetQueryable<RadiogroupQuestion>().Where(x => x.PollId == pollId)
                                                                               .ToListAsync());
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Update(RadiogroupQuestion entity)
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