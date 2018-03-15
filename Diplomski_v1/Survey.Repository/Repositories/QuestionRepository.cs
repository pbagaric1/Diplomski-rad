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
    public class QuestionRepository : IQuestionRepository
    {

        private readonly IGenericRepository GenericRepository;

        public QuestionRepository(IGenericRepository _genericRepository)
        {
            this.GenericRepository = _genericRepository;
        }


        public async Task<int> Add(Question entity)
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

        public async Task<int> Delete(Question entity)
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
                var entity = await GenericRepository.Get<Question>(id);

                if (entity == null)
                    return 0;

                return await GenericRepository.Delete(entity);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Question> Get(Guid id)
        {
            try
            {
                var response = (await GenericRepository.Get<Question>(id));
                return response;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Question>> GetAll()
        {
            try
            {
                var response = (await GenericRepository.GetAll<Question>());
                return response;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Question>> GetQuestionsByPoll(Guid pollId)
        {
            try
            {
                var response = Mapper.Map<IEnumerable<Question>>(await GenericRepository
                    .GetQueryable<Question>().Where(x => x.PollId == pollId)
                    .ToListAsync());
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Update(Question entity)
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
