using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Survey.DAL.Models;
using Survey.Repository.Common.IGenericRepository;
using Survey.Repository.Common.IRepositories;

namespace Survey.Repository.Repositories
{
    public class InputTypeRepository : IInputTypeRepository
    {
        private readonly IGenericRepository GenericRepository;

        public InputTypeRepository(IGenericRepository _genericRepository)
        {
            this.GenericRepository = _genericRepository;

        }
        public async Task<int> Add(QuestionType entity)
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

        public async Task<int> Delete(QuestionType entity)
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
                var entity = await GenericRepository.Get<QuestionType>(id);

                if (entity == null)
                    return 0;

                return await GenericRepository.Delete(entity);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<QuestionType> Get(Guid id)
        {
            try
            {
                var response = (await GenericRepository.Get<QuestionType>(id));
                return response;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<QuestionType>> GetAll()
        {
            try
            {
                var response = (await GenericRepository.GetAll<QuestionType>());
                return response;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public async Task<IEnumerable<InputType>> GetByUsername(string username)
        //{
        //    try
        //    {
        //        var response = Mapper.Map<IEnumerable<InputType>>(await GenericRepository
        //            .GetQueryable<InputType>().Where(x => x.AspNetUser.UserName == username)
        //            .ToListAsync());
        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public async Task<IEnumerable<InputType>> GetInputTypesByType(Guid InputTypeTypeId)
        //{
        //    try
        //    {
        //        var response = Mapper.Map<IEnumerable<InputType>>(await GenericRepository
        //            .GetQueryable<InputType>().Where(x => x.InputTypeTypeId == InputTypeTypeId)
        //            .ToListAsync());
        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public async Task<int> Update(QuestionType entity)
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
