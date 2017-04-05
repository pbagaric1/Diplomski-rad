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
    public class QuestionRepository : IQuestionRepository
    {

        private readonly IGenericRepository GenericRepository;

        public QuestionRepository(IGenericRepository _genericRepository)
        {
            this.GenericRepository = _genericRepository;
        }


        public async Task<int> Add(IQuestionDomain entity)
        {
            try
            {
                return await GenericRepository.Add(Mapper.Map<Question>(entity));
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Delete(IQuestionDomain entity)
        {
            try
            {
                return await GenericRepository.Delete(Mapper.Map<Question>(entity));
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
                var entity = GenericRepository.Get<Question>(id);

                if (entity == null)
                    return 0;

                return await GenericRepository.Delete(entity);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IQuestionDomain> Get(Guid id)
        {
            try
            {
                var response = Mapper.Map<IQuestionDomain>(await GenericRepository.Get<Question>(id));
                return response;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<IQuestionDomain>> GetAll()
        {
            try
            {
                var response = Mapper.Map<IEnumerable<IQuestionDomain>>(await GenericRepository.GetAll<Question>());
                return response;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<IQuestionDomain>> GetQuestionsBySurvey(Guid pollId)
        {
            try
            {
                var response = Mapper.Map<IEnumerable<IQuestionDomain>>(await GenericRepository
                    .GetQueryable<Question>().Where(x => x.PollId == pollId)
                    .ToListAsync());
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Update(IQuestionDomain entity)
        {
            try
            {
                return await GenericRepository.Update(Mapper.Map<Question>(entity));
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
