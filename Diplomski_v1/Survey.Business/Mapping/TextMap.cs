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
    public static class TextMap
    {
        public static Question MapToDto(ReceivedQuestionView item, int questionOrder)
        {
            if (item == null)
                return null;

            var questionType = (int)Enum.Parse(typeof(QuestionTypeEnum), item.type);

      var questionName = item.title;

      return new Question()
            {
                Title = item.title,
                Name = questionName,
                AnswerRequired = item.isRequired,
                Id = Guid.NewGuid(),
                QuestionOrder = questionOrder,
                QuestionTypeId = questionType
            };
        }
    }
}
