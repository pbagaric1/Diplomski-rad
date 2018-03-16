﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Survey.DAL.Models;

namespace Survey.Repository.Common.IRepositories
{
    public interface IRadiogroupQuestionRepository
    {
        Task<int> Add(RadiogroupQuestion entity);
        Task<int> Delete(Guid id);
        Task<int> Delete(RadiogroupQuestion entity);
        Task<int> Update(RadiogroupQuestion entity);
        Task<RadiogroupQuestion> Get(Guid id);
        Task<IEnumerable<RadiogroupQuestion>> GetAll();
    }
}
