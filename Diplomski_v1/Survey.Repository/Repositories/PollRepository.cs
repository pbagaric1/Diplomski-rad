using Survey.Business.Mapping.DtoToView;
using Survey.Business.Models.ViewModels;
using Survey.DAL.Models;
using Survey.Repository.Common.IGenericRepository;
using Survey.Repository.Common.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Repository.Repositories
{
  public class PollRepository : IPollRepository
  {
    private readonly IGenericRepository GenericRepository;

    public PollRepository(IGenericRepository _genericRepository)
    {
      this.GenericRepository = _genericRepository;
    }

    public async Task<int> Add(Poll entity)
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

    public async Task<int> AddSavedPoll(SavedPoll entity)
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

    public async Task<int> DeleteSavedPoll(Guid id)
    {
      try
      {
        var entity = await GenericRepository.Get<SavedPoll>(id);

        if (entity == null)
          return 0;

        return await GenericRepository.Delete(entity);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public async Task<int> Delete(Poll entity)
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

    public async Task<int> Delete(Guid id)
    {
      try
      {
        var entity = await GenericRepository.Get<Poll>(id);

        if (entity == null)
          return 0;

        foreach (var question in entity.Questions)
        {
          var answers = (await GenericRepository
            .GetQueryable<Answer>().Where(x => x.QuestionId == question.Id)
            .ToListAsync());

          if (answers.Count != 0)
          {
            foreach (var answer in answers)
            {
              await GenericRepository.Delete(answer);
            }
          }
        }
        

        return await GenericRepository.Delete(entity);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public async Task<Poll> Get(Guid id)
    {
      try
      {
        var response = (await GenericRepository.Get<Poll>(id));

        return response;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public async Task<PollView> GetView(Guid id)
    {
      try
      {
        var entity = await GenericRepository.Get<Poll>(id);

        var pollView = PollToViewMap.MapToDto(entity);

        return pollView;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public async Task<IEnumerable<Poll>> GetAll()
    {
      try
      {
        var response = (await GenericRepository.GetAll<Poll>());
        return response;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public async Task<IEnumerable<PollView>> GetAllView()
    {
      try
      {
        var response = (await GenericRepository
          .GetQueryable<Poll>().Where(x => x.IsFinal == true)
          .ToListAsync());

        var pollViewList = response.Select(poll => PollToViewMap.MapToDto(poll)).ToList();

        return pollViewList;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public async Task<int> CheckIfUserAlreadySavedPoll(string id)
    {
      try
      {
        var response = (await GenericRepository
          .GetQueryable<SavedPoll>().Where(x => x.AspNetUserId == id)
          .FirstOrDefaultAsync());

        if (response != null)
        {
          await DeleteSavedPoll(response.Id);
          return await Delete(response.PollId);

        }
        else return 0;

      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public async Task<int> UpdateTakeCount(Guid id)
    {
      try
      {
        var toBeUpdated = await Get(id);

        if (toBeUpdated == null)
          return 0;

        toBeUpdated.TakesCount++;

        return await GenericRepository.Update((toBeUpdated));

      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public async Task<PagedResponse> GetNumberOfPolls(int pageIndex, int pageSize)
    {
      try
      {
        var response = await GenericRepository.GetAll<Poll>();

        var orderedList = response.Where(x => x.Visibility == true && x.IsFinal == true).Select(x => new Poll
        {
          Id = x.Id,
          CreatedOn = x.CreatedOn,
          //AspNetUserId = x.AspNetUserId,
          Description = x.Description,
          Name = x.Name,
          Organization = x.Organization,
          Questions = x.Questions.OrderBy(q => q.QuestionOrder).ToList(),
          AspNetUser = x.AspNetUser,
          Visibility = x.Visibility,
          ActivityEndTime = x.ActivityEndTime,
          ActivityStartTime = x.ActivityStartTime
        }).ToList();

        var pollViewList = orderedList
            .Select(poll => PollToViewMap.MapToDto(poll))
            .OrderByDescending(p => p.createdOn)
            .Skip(pageSize * (pageIndex - 1))
            .Take(pageSize)
            .ToList();

        return new PagedResponse()
        {
          Total = orderedList.Count(),
          Data = pollViewList
        };
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public async Task<IEnumerable<PollView>> GetByUsername(string userId)
    {
      try
      {
        var response = (await GenericRepository
            .GetQueryable<Poll>().Where(x => x.AspNetUserId == userId)
            .ToListAsync());

        var pollViewList = response.Select(poll => PollToViewMap.MapToDto(poll)).ToList();

        return pollViewList;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public async Task<PollView> GetSavedPoll(string userId)
    {
      try
      {
        var response = (await GenericRepository
          .GetQueryable<SavedPoll>().Where(x => x.AspNetUserId == userId)
          .Select(x => x.PollId)
          .FirstOrDefaultAsync());
        
        return await GetView(response);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    //public async Task<IEnumerable<Poll>> GetPollsByType(Guid pollTypeId)
    //{
    //    try
    //    {
    //        var response = Mapper.Map<IEnumerable<Poll>>(await GenericRepository
    //            .GetQueryable<Poll>().Where(x => x.PollTypeId == pollTypeId)
    //            .ToListAsync());
    //        return response;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}

    public async Task<int> Update(Poll entity)
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