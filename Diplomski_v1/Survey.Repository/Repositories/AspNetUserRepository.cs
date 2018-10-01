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
    private readonly IPollRepository PollRepository;

    public AspNetUserRepository(IGenericRepository _genericRepository, IPollRepository _pollRepository)
    {
      this.GenericRepository = _genericRepository;
      this.PollRepository = _pollRepository;
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
        var polls = (await GenericRepository
          .GetQueryable<Poll>().Where(x => x.AspNetUserId == id)
          .ToListAsync());
        
        foreach (var poll in polls)
        {
          await PollRepository.Delete(poll.Id);
        }

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
        var response = (await GenericRepository.GetQueryable<AspNetUser>().ToListAsync());
        var users = response.Where(x => x.UserRole != "Admin").Select(x => new AspNetUser { Id = x.Id, UserName = x.UserName, UserRole = x.UserRole, Email = x.Email }).ToList();

        return users;
      }

      catch (Exception ex)
      {
        throw ex;
      }
    }

    public async Task<bool> CheckIfUsernameTaken(AspNetUser user)
    {
      try
      {
        var response = await GenericRepository.GetQueryable<AspNetUser>().ToListAsync();

        var usernames = new List<string>();

        foreach (var username in response)
        {
          usernames.Add(username.UserName);
        }

        foreach (var username in usernames)
        {
          if (user.UserName == username)
            return true;
        }

        return false;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public async Task<bool> CheckIfEmailTaken(AspNetUser user)
    {
      try
      {
        var response = await GenericRepository.GetQueryable<AspNetUser>().ToListAsync();

        var emails = new List<string>();

        foreach (var email in response)
        {
          emails.Add(email.Email);
        }

        foreach (var email in emails)
        {
          if (user.Email == email)
            return true;
        }

        return false;
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