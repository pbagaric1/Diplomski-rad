using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Survey.Business.Models.ViewModels;
using Survey.DAL.Models;

namespace Survey.Business.Mapping.DtoToView
{
    public static class PollToViewMap
    {
        public static PollView MapToDto(Poll item)
        {
            if (item == null)
                return null;

            var questionList = new List<ReceivedQuestionView>();

            foreach (var receivedQuestion in item.Questions)
            {
                switch (receivedQuestion.QuestionType.Type)
                {
                    case "rating":
                        questionList.Add(RatingToViewMap.MapToDto(receivedQuestion));
                        break;

                    case "radiogroup":
                        questionList.Add(ChkboxRadioToViewMap.MapToDto(receivedQuestion));
                        break;

                    case "checkbox":
                        questionList.Add(ChkboxRadioToViewMap.MapToDto(receivedQuestion));
                        break;

                        default: questionList.Add(TextToViewMap.MapToDto(receivedQuestion));
                            break;
                }
                
            }

            var pageView = new PageView()
            {
                questions = questionList
            };

            var pageViewList = new List<PageView>();

            pageViewList.Add(pageView);

            return new PollView()
            {
                Id = item.Id,
                userId = item.AspNetUserId,
                createdOn = item.CreatedOn,
                instructions = item.Instructions,
                title = item.Name,
                pages = pageViewList
            };
        }
    }
}