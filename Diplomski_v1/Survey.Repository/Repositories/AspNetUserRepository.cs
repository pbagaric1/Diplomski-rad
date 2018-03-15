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
    public class AspNetUserRepository : IAspNetUserRepository
    {
        private readonly IGenericRepository GenericRepository;

        public AspNetUserRepository(IGenericRepository _genericRepository)
        {
            this.GenericRepository = _genericRepository;
        }


        public async Task<int> Add(AspNetUser entity)
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

        public async Task<int> Delete(AspNetUser entity)
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

        public async Task<AspNetUser> Get(string id)
        {
            try
            {
                var response = (await GenericRepository.Get<AspNetUser>(id));
                return response;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<AspNetUser>> GetAll()
        {
            try
            {
                var response = (await GenericRepository.GetAll<AspNetUser>());
                return response;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<AspNetUser>> GetAllEmails()
        {
            try
            {
                var response = (await GenericRepository.GetQueryable<AspNetUser>()
                    .ToListAsync());
                var responseEmails = response.Select(a => new AspNetUser { Email = a.Email }).ToList();

                return (responseEmails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<AspNetUser>> GetAllUsernames()
        {
            try
            {
                var response = (await GenericRepository.GetQueryable<AspNetUser>().ToListAsync());

                var usernames = response.Select(a => new AspNetUser { UserName = a.UserName }).ToList();

                return (usernames);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AspNetUser> GetByUsername(string username)
        {
            try
            {
                var response = (await GenericRepository
                    .GetQueryable<AspNetUser>().Where(x => x.UserName == username)
                    .FirstOrDefaultAsync());
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Update(AspNetUser entity)
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
