﻿using Survey.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Service.Common
{
    public interface IPollTypeService
    {
        Task<int> Add(IPollTypeDomain entity);
        Task<int> Delete(Guid id);
        Task<int> Delete(IPollTypeDomain entity);
        Task<int> Update(IPollTypeDomain entity);
        Task<IPollTypeDomain> Get(Guid id);
        Task<IEnumerable<IPollTypeDomain>> GetAll();
    }
}
