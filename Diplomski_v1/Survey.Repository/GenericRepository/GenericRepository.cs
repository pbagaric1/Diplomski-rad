using Survey.Repository.Common.IGenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Survey.DAL.Common;
using Survey.Repository.Common;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace Survey.Repository.GenericRepository
{
    public class GenericRepository : IGenericRepository
    {
        private readonly ISurveyContext Context;
        private readonly IUnitOfWork UnitOfWork;

        public GenericRepository(ISurveyContext _context)
        {
            this.Context = _context;
        }

        public async Task<int> Add<T>(T entity) where T : class
        {
            try
            {
                Context.Set<T>().Add(entity);
                return await Context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> Delete<T>(T entity) where T : class
        {
            try
            {
                Context.Set<T>().Remove(entity);
                return await Context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> Delete<T>(string id) where T : class
        {
            try
            {
                T entity = await Get<T>(id);
                Context.Set<T>().Remove(entity);
                return await Context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> Delete<T>(Guid id) where T : class
        {
            try
            {
                T entity = await Get<T>(id);
                Context.Set<T>().Remove(entity);
                return await Context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<T> Get<T>(string id) where T : class
        {
            try
            {
                var response = await Context.Set<T>().FindAsync(id);
                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<T> Get<T>(Guid id) where T : class
        {
            try
            {
                var response = await Context.Set<T>().FindAsync(id);
                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<T>> GetAll<T>() where T : class
        {
            try
            {
                var response = await Context.Set<T>().ToListAsync();
                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IQueryable<T> GetQueryable<T>() where T : class
        {
            try
            {
                return Context.Set<T>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<T> GetWhere<T>(Expression<Func<T, bool>> match) where T : class
        {
            try
            {
                var response = await Context.Set<T>().FirstAsync(match);
                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> Update<T>(T entity) where T : class
        {
            try
            {
                Context.Set<T>().AddOrUpdate(entity);
                var response = await Context.SaveChangesAsync();
                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
