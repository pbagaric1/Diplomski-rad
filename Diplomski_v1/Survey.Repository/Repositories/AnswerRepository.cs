using Survey.Repository.Common.IGenericRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Survey.Business.Models.ViewModels;
using Survey.DAL.Models;
using Survey.Repository.Common.IRepositories;

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

        public async Task<IEnumerable<DataView>> GetQuestionResults(Guid questionId)
        {
            try
            {
                var answers = await GenericRepository
                    .GetQueryable<Answer>().Where(x => x.QuestionId == questionId)
                    .Select(i => new { i.Text, i.Question.QuestionType.Type, i.Question.QuestionChoices })
                    .ToListAsync();

                var data = new List<DataView>();

                var firstAnswer = answers.First();

                switch (firstAnswer.Type)
                {
                    case "rating":
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
                        break;
                    }

                    case "radiogroup":
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
                        break;
                    }

                    case "checkbox":
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
                        break;
                    }

                    default:

                        break;
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

                return data;
            }
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