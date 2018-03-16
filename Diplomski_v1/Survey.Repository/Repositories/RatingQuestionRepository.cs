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
    public class RatingQuestionRepository : IRatingQuestionRepository
    {

        private readonly IGenericRepository GenericRepository;

        public RatingQuestionRepository(IGenericRepository _genericRepository)
        {
            this.GenericRepository = _genericRepository;
        }


        public async Task<int> Add(RatingQuestion entity)
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

        public async Task<int> Delete(RatingQuestion entity)
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
                var entity = await GenericRepository.Get<RatingQuestion>(id);

                if (entity == null)
                    return 0;

                return await GenericRepository.Delete(entity);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<RatingQuestion> Get(Guid id)
        {
            try
            {
                var response = (await GenericRepository.Get<RatingQuestion>(id));
                return response;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<RatingQuestion>> GetAll()
        {
            try
            {
                var response = (await GenericRepository.GetAll<RatingQuestion>());
                return response;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<RatingQuestion>> GetRatingQuestionsByPoll(Guid pollId)
        {
            try
            {
                var response = Mapper.Map<IEnumerable<RatingQuestion>>(await GenericRepository
                    .GetQueryable<RatingQuestion>().Where(x => x.PollId == pollId)
                    .ToListAsync());
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Update(RatingQuestion entity)
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
