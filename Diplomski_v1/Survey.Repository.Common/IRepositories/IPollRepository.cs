using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Survey.Business.Models.ViewModels;
using Survey.DAL.Models;

namespace Survey.Repository.Common.IRepositories
{
    public interface IPollRepository
    {
        Task<int> Add(Poll entity);
        Task<int> Delete(Guid id);
        Task<int> Delete(Poll entity);
        Task<int> Update(Poll entity);
        Task<Poll> Get(Guid id);
        Task<PollView> GetView(Guid id);
        Task<IEnumerable<Poll>> GetAll();
        Task<IEnumerable<PollView>> GetAllView();
        //Task<IEnumerable<Poll>> GetPollsByType(Guid pollTypeId);
        Task<IEnumerable<PollView>> GetByUsername(string userId);
        Task<PagedResponse> GetNumberOfPolls(int pageNumber, int itemsNumber);
    }
}
