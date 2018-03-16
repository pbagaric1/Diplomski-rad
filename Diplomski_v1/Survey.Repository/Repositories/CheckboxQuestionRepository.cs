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
    public class CheckboxQuestionRepository : ICheckboxQuestionRepository
    {

        private readonly IGenericRepository GenericRepository;

        public CheckboxQuestionRepository(IGenericRepository _genericRepository)
        {
            this.GenericRepository = _genericRepository;
        }


        public async Task<int> Add(CheckboxQuestion entity)
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

        public async Task<int> Delete(CheckboxQuestion entity)
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
                var entity = await GenericRepository.Get<CheckboxQuestion>(id);

                if (entity == null)
                    return 0;

                return await GenericRepository.Delete(entity);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CheckboxQuestion> Get(Guid id)
        {
            try
            {
                var response = (await GenericRepository.Get<CheckboxQuestion>(id));
                return response;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<CheckboxQuestion>> GetAll()
        {
            try
            {
                var response = (await GenericRepository.GetAll<CheckboxQuestion>());
                return response;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<CheckboxQuestion>> GetCheckboxQuestionsByPoll(Guid pollId)
        {
            try
            {
                var response = Mapper.Map<IEnumerable<CheckboxQuestion>>(await GenericRepository
                    .GetQueryable<CheckboxQuestion>().Where(x => x.PollId == pollId)
                    .ToListAsync());
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Update(CheckboxQuestion entity)
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
