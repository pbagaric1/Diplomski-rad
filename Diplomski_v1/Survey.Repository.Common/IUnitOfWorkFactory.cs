using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Repository.Common
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}
