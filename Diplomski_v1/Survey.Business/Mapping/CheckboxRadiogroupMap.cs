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
    public static class CheckboxRadiogroupMap
    {
        public static Question MapToDto(ReceivedQuestionView item, int questionOrder)
        {
            if (item == null)
                return null;

            var choiceList = new List<QuestionChoice>();
            var questionOptionGroup = new QuestionOptionGroup();
            var questionOptionList = new List<QuestionOption>();

            var questionId = Guid.NewGuid();

            if (item.choices != null)
            {
                foreach (var choice in item.choices)
                {
                    var questionChoiceId = Guid.NewGuid();

                    QuestionChoice questionChoice = new QuestionChoice()
                    {
                        Id = questionChoiceId,
                        Name = choice
                    };

                    QuestionOption questionOption = new QuestionOption()
                    {
                        Id = Guid.NewGuid(),
                        QuestionChoiceId = questionChoiceId

                    };
                    choiceList.Add(questionChoice);
                    questionOptionList.Add(questionOption);
                }
            }

            var questionType = (int)Enum.Parse(typeof(QuestionTypeEnum), item.type);

            return new Question()
            {
                Title = item.title,
                Name = item.name,
                AnswerRequired = item.isRequired,
                Id = questionId,
                QuestionChoices = choiceList,
                QuestionOrder = questionOrder,
                QuestionTypeId = questionType,
                //QuestionOptions = questionOptionList
            };
        }
    }
}