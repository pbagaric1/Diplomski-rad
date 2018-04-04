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
using Survey.Business.Mapping.DtoToView;
using Survey.Business.Models.ViewModels;

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
                var response = (await GenericRepository.GetAll<Poll>());

                var pollViewList = response.Select(poll => PollToViewMap.MapToDto(poll)).ToList();

                return pollViewList;
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

                var orderedList = response.Select(x => new Poll
                {
                    Id = x.Id,
                    CreatedOn = x.CreatedOn,
                    AspNetUserId = x.AspNetUserId,
                    Instructions = x.Instructions,
                    Name = x.Name,
                    OrganizationId = x.OrganizationId,
                    Questions = x.Questions.OrderBy(q => q.QuestionOrder).ToList()
                }).ToList();

                var pollViewList = orderedList
                    .Select(poll => PollToViewMap.MapToDto(poll))
                    .OrderByDescending(p => p.createdOn)
                    .Skip(pageSize * (pageIndex - 1))
                    .Take(pageSize)
                    .ToList();

                return new PagedResponse()
                {
                    Total = response.Count(),
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

                //List<PollView> pollViewList = new List<PollView>();

                var pollViewList = response.Select(poll => PollToViewMap.MapToDto(poll)).ToList();

                return pollViewList;

                //foreach (var poll in response)
                //{
                //    pollViewList.Add(PollToViewMap.MapToDto(poll));
                //}
                //return pollViewList;
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