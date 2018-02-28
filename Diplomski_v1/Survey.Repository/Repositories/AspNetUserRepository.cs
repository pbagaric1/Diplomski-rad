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
    public class AspNetUserRepository : IAspNetUserRepository
    {
        private readonly IGenericRepository GenericRepository;

        public AspNetUserRepository(IGenericRepository _genericRepository)
        {
            this.GenericRepository = _genericRepository;
        }


        public async Task<int> Add(IAspNetUserDomain entity)
        {
            try
            {
                return await GenericRepository.Add(Mapper.Map<AspNetUser>(entity));
            }
        
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Delete(IAspNetUserDomain entity)
        {
            try
            {
                return await GenericRepository.Delete(Mapper.Map<AspNetUser>(entity));
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Delete(string id)
        {
            try
            {
                var entity = await GenericRepository.Get<AspNetUser>(id);

                if (entity == null)
                    return 0;

                return await GenericRepository.Delete(entity);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IAspNetUserDomain> Get(string id)
        {
            try
            {
                var response = Mapper.Map<IAspNetUserDomain>(await GenericRepository.Get<AspNetUser>(id));
                return response;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<IAspNetUserDomain>> GetAll()
        {
            try
            {
                var response = Mapper.Map<IEnumerable<IAspNetUserDomain>>(await GenericRepository.GetAll<AspNetUser>());
                return response;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<IAspNetUserDomain>> GetAllEmails()
        {
            try
            {
                var response = (await GenericRepository.GetQueryable<AspNetUser>()
                    .ToListAsync());
                var responseEmails = response.Select(a => new AspNetUser { Email = a.Email }).ToList();

                return Mapper.Map<IEnumerable<IAspNetUserDomain>>(responseEmails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<IAspNetUserDomain>> GetAllUsernames()
        {
            try
            {
                var response = (await GenericRepository.GetQueryable<AspNetUser>().ToListAsync());

                var usernames = response.Select(a => new AspNetUser{ UserName = a.UserName }).ToList();

                return Mapper.Map<IEnumerable<IAspNetUserDomain>>(usernames);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IAspNetUserDomain> GetByUsername(string username)
        {
            try
            {
                var response = Mapper.Map<IAspNetUserDomain>(await GenericRepository
                    .GetQueryable<AspNetUser>().Where(x => x.UserName == username)
                    .FirstOrDefaultAsync());
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Update(IAspNetUserDomain entity)
        {
            try
            {
                return await GenericRepository.Update(Mapper.Map<AspNetUser>(entity));
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
