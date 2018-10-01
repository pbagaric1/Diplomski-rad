using Survey.Business.Constants;
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
  public class AnswerRepository : IAnswerRepository
  {
    private readonly IGenericRepository GenericRepository;

    public AnswerRepository(IGenericRepository _genericRepository)
    {
      this.GenericRepository = _genericRepository;
    }

    public async Task<int> Add(Answer entity)
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

    public async Task<int> Delete(Answer entity)
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
        var entity = await GenericRepository.Get<Answer>(id);

        if (entity == null)
          return 0;

        return await GenericRepository.Delete(entity);
        //return await GenericRepository.Delete<Answer>(id);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public async Task<Answer> Get(Guid id)
    {
      try
      {
        var response = (await GenericRepository.Get<Answer>(id));
        return response;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public async Task<IEnumerable<Answer>> GetAll()
    {
      try
      {
        var response = (await GenericRepository.GetAll<Answer>());
        return response;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public async Task<IEnumerable<Answer>> GetAnswersByQuestion(Guid questionId)
    {
      try
      {
        var response = await GenericRepository
            .GetQueryable<Answer>().Where(x => x.QuestionId == questionId)
            .ToListAsync();
        return response;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public async Task<int> UpdateUserPoll(UserPoll userPoll)
    {
      try
      {
        return await GenericRepository.Add((userPoll));
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public async Task<bool> CheckIfUserVoted(string userId, Guid surveyId)
    {
      try
      {
        var response = await GenericRepository
          .GetQueryable<UserPoll>().Where(x => x.AspNetUserId == userId && x.PollId == surveyId)
          .FirstOrDefaultAsync();

        if (response == null)
          return false;
        else return true;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
    

    public async Task<IEnumerable<DataView>> GetQuestionResults(Guid questionId)
    {
      try
      {
        var answers = await GenericRepository
            .GetQueryable<Answer>().Where(x => x.QuestionId == questionId)
            .Select(i => new { i.Text, i.Question.QuestionType.Type, i.Question.QuestionChoices })
            .ToListAsync();

        if (answers.Count == 0)
          return null;

        var data = new List<DataView>();

        var firstAnswer = answers.First();

        if (firstAnswer.Type == QuestionTypes.Rating)
        {
          foreach (var choice in firstAnswer.Text)
          {
            var answersSum = answers.Select(x => x.Text).Select(decimal.Parse).Sum();
            var answersCount = answers.Select(x => x.Text).Count();
            decimal averageRating = answersSum / answersCount;

            string output = averageRating.ToString("0.00");

            var dataView = new DataView()
            {
              name = "Rating",
              value = decimal.Round(averageRating, 2, MidpointRounding.AwayFromZero)
            };

            data.Add(dataView);
          }
        }
        else if (firstAnswer.Type == QuestionTypes.Radiogroup)
        {
          foreach (var choice in firstAnswer.QuestionChoices)
          {
            var dataView = new DataView()
            {
              name = choice.Name,
              value = answers.Where(x => x.Text == choice.Name).Count()
            };
            data.Add(dataView);
          }
        }
        else if (firstAnswer.Type == QuestionTypes.Checkbox)
        {
          foreach (var choice in firstAnswer.QuestionChoices)
          {
            var dataView = new DataView()
            {
              name = choice.Name,
              value = answers.Where(x => x.Text == choice.Name).Count()
            };
            data.Add(dataView);
          }
        }
        else if (firstAnswer.Type == QuestionTypes.Text)
        {
          var textAnswers = answers.Select(x => x.Text).ToList();

          var dataView = new DataView()
          {
            TextAnswers = textAnswers
          };

          data.Add(dataView);
        }

        return data;
      }

      //        foreach (var answer in answers)
      //{
      //    if (data.Any())
      //        break;

      //    switch (answer.Type)
      //    {
      //        case "rating":

      //            break;

      //        case "radiogroup":
      //        {
      //            foreach (var choice in answer.QuestionChoices)
      //            {
      //                var dataView = new DataView()
      //                {
      //                    name = choice.Name,
      //                    value = answers.Where(x => x.Text == choice.Name).Count()
      //                };
      //                    data.Add(dataView);
      //            }
      //            }

      //            break;

      //        default:

      //            break;
      //    }
      //}
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public async Task<int> Update(Answer entity)
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