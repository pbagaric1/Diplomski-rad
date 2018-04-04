using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Survey.Business.Enums;
using Survey.Business.Models.ViewModels;
using Survey.DAL.Models;

namespace Survey.Business.Mapping
{
    public static class RatingMap
    {
        public static Question MapToDto(ReceivedQuestionView item, int questionOrder)
        {
            if (item == null)
                return null;
            var questionOptionGroup = new QuestionOptionGroup();

            if (item.mininumRateDescription != null || item.maximumRateDescription != null)
            {
                questionOptionGroup.MaximumRateDescription = item.maximumRateDescription;
                questionOptionGroup.MinimumRateDescription = item.mininumRateDescription;
            }


            var questionType = (int)Enum.Parse(typeof(QuestionTypeEnum), item.type);

            return new Question()
            {
                Title = item.title,
                Name = item.name,
                AnswerRequired = item.isRequired,
                Id = Guid.NewGuid(),
                QuestionOptionGroup = questionOptionGroup,
                QuestionOrder = questionOrder,
                QuestionOptionGroupId = questionOptionGroup.Id,
                QuestionTypeId = questionType
            };
        }
    }
}
