using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Survey.Business.Models.ViewModels;
using Survey.DAL.Models;

namespace Survey.Business.Mapping.DtoToView
{
    public static class RatingToViewMap
    {
        public static ReceivedQuestionView MapToDto(Question item)
        {
            if (item == null)
                return null;

            return new ReceivedQuestionView()
            {
                title = item.Title,
                type = item.QuestionType.Type,
                isRequired = item.AnswerRequired,
                minimumRateDescription = item.QuestionOptionGroup.MinimumRateDescription,
                maximumRateDescription = item.QuestionOptionGroup.MaximumRateDescription
            };
        }
    }
}
