using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Survey.Business.Models.ViewModels;
using Survey.DAL.Models;

namespace Survey.Business.Mapping.DtoToView
{
    public static class TextToViewMap
    {
        public static ReceivedQuestionView MapToDto(Question item)
        {
            if (item == null)
                return null;

            return new ReceivedQuestionView()
            {
                title = item.Title,
                name = item.Name,
                type = item.QuestionType.Type,
                isRequired = item.AnswerRequired
            };
        }
    }
}
