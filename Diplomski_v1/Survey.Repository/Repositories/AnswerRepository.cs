using Survey.Repository.Common.IGenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Survey.Model.Common;
using AutoMapper;
using System.Data.Entity;
using Survey.DAL.Models;

namespace Survey.Repository.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly IGenericRepository GenericRepository;

        public AnswerRepository(IGenericRepository _genericRepository)
        {
            this.GenericRepository = _genericRepository;
        }


        public async Task<int> Add(IAnswerDomain entity)
        {
            try
            {
                return await GenericRepository.Add(Mapper.Map<Answer>(entity));
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Delete(IAnswerDomain entity)
        {
            try
            {
                return await GenericRepository.Delete(Mapper.Map<Answer>(entity));
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
                var entity = await GenericRepository.Get<Answer>(id);

                if (entity == null)
                    return 0;

                return await GenericRepository.Delete(entity);
                //return await GenericRepository.Delete<Answer>(id);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IAnswerDomain> Get(Guid id)
        {
            try
            {
                var response = Mapper.Map<IAnswerDomain>(await GenericRepository.Get<Answer>(id));
                return response;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<IAnswerDomain>> GetAll()
        {
            try
            {
                var response = Mapper.Map<IEnumerable<IAnswerDomain>>(await GenericRepository.GetAll<Answer>());
                return response;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public async Task<IEnumerable<IAnswerDomain>> GetAnswersByQuestion(Guid questionId)
        //{
        //    try
        //    {
        //        var response = Mapper.Map<IEnumerable<IAnswerDomain>>(await GenericRepository
        //            .GetQueryable<Answer>().Where(x => x.QuestionId == questionId)
        //            .ToListAsync());
        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public async Task<int> Update(IAnswerDomain entity)
        {
            try
            {
                return await GenericRepository.Update(Mapper.Map<Answer>(entity));
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
