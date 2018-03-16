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
    public class TextQuestionRepository : ITextQuestionRepository
    {

        private readonly IGenericRepository GenericRepository;

        public TextQuestionRepository(IGenericRepository _genericRepository)
        {
            this.GenericRepository = _genericRepository;
        }


        public async Task<int> Add(TextQuestion entity)
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

        public async Task<int> Delete(TextQuestion entity)
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
                var entity = await GenericRepository.Get<TextQuestion>(id);

                if (entity == null)
                    return 0;

                return await GenericRepository.Delete(entity);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TextQuestion> Get(Guid id)
        {
            try
            {
                var response = (await GenericRepository.Get<TextQuestion>(id));
                return response;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<TextQuestion>> GetAll()
        {
            try
            {
                var response = (await GenericRepository.GetAll<TextQuestion>());
                return response;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<TextQuestion>> GetTextQuestionsByPoll(Guid pollId)
        {
            try
            {
                var response = Mapper.Map<IEnumerable<TextQuestion>>(await GenericRepository
                    .GetQueryable<TextQuestion>().Where(x => x.PollId == pollId)
                    .ToListAsync());
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Update(TextQuestion entity)
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
