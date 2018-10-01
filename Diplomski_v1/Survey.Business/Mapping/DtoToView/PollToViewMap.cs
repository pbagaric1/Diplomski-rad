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

            foreach (var receivedQuestion in item.Questions.OrderBy(x => x.QuestionOrder))
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
                //userId = item.AspNetUserId,
                createdOn = item.CreatedOn,
                description = item.Description,
                title = item.Name,
                pages = pageViewList,
                userName = item.AspNetUser.UserName,
                visibility = item.Visibility,
                activityEndTime = item.ActivityEndTime,
                activityStartTime = item.ActivityStartTime,
                organization = item.Organization,
                takesCount = item.TakesCount
            };
        }
    }
}