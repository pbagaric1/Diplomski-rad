using Survey.DAL.Common;
using Survey.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ISurveyContext Context;

        public UnitOfWork(ISurveyContext _context)
        {
            this.Context = _context;
        }

        public async Task<int> Commit()
        {
            return await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
