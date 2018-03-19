using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Survey.Business.Enums;
using Survey.Business.Models.ViewModels;
using Survey.DAL.Models;

namespace Survey.Business.Mapping
{
    public static class QuestionMap
    {
        public static Question MapToDto(ReceivedQuestionView item, int questionOrder)
        {
            if (item == null)
                return null;

            var choiceList = new List<QuestionChoice>();
            var questionOptionGroup = new QuestionOptionGroup();
            

            if (item.choices != null)
            {
                foreach (var choice in item.choices)
                {
                    QuestionChoice questionChoice = new QuestionChoice()
                    {
                        Id = Guid.NewGuid(),
                        Name = choice
                    };
                    choiceList.Add(questionChoice);
                }
            }

            var questionType = (int)Enum.Parse(typeof(QuestionTypeEnum), item.type);

            return new Question()
            {
                Title = item.title,
                AnswerRequired = item.isRequired,
                Id = Guid.NewGuid(),
                QuestionChoices = choiceList,
                QuestionOrder = questionOrder,
                QuestionTypeId = questionType
            };
        }
    }
}