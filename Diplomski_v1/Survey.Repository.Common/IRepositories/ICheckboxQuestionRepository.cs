using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Survey.DAL.Models;

namespace Survey.Repository.Common.IRepositories
{
    public interface ICheckboxQuestionRepository
    {
        Task<int> Add(CheckboxQuestion entity);
        Task<int> Delete(Guid id);
        Task<int> Delete(CheckboxQuestion entity);
        Task<int> Update(CheckboxQuestion entity);
        Task<CheckboxQuestion> Get(Guid id);
        Task<IEnumerable<CheckboxQuestion>> GetAll();
    }
}
