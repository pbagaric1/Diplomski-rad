using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Survey.Business.Models.QuestionTypeModels;
using Survey.Business.Models.ViewModels;
using Survey.DAL.Models;

namespace Survey.Business.Mapping
{
    public static class TextMap
    {
        public static TextQuestion MapToDto(ReceivedQuestionView item, int questionOrder)
        {
            if (item == null)
                return null;

            return new TextQuestion()
            {
                Title = item.Title,
                IsRequired = item.isRequired,
                QuestionOrder = questionOrder,
                Id = Guid.NewGuid(),
                Type = QuestionType.Text
            };
        }
    }
}
