using Survey.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Repository
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IUnitOfWork UnitOfWork;

        public UnitOfWorkFactory(IUnitOfWork _unitOfWork)
        {
            this.UnitOfWork = _unitOfWork;
        }

        public IUnitOfWork Create()
        {
            return this.UnitOfWork;
        }
    }
}
