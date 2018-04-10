using System;
using System.Collections.Generic;
using Survey.Business.Models.ViewModels;
using Survey.DAL.Models;

namespace Survey.Business.Mapping.DtoToView
{
    public static class ChkboxRadioToViewMap
    {
        public static ReceivedQuestionView MapToDto(Question item)
        {
            if (item == null)
                return null;

            var choiceList = new List<string>();
            var questionOptionGroup = new QuestionOptionGroup();

            if (item.QuestionChoices != null)
            {
                foreach (var choice in item.QuestionChoices)
                {
                    choiceList.Add(choice.Name);
                }
            }

            return new ReceivedQuestionView()
            {
                id = item.Id,
                title = item.Title,
                name = item.Name,
                choices = choiceList,
                type = item.QuestionType.Type,
                isRequired = item.AnswerRequired
            };
        }
    }
}