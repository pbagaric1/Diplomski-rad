﻿using System;
using System.Collections.Generic;
using Survey.Business.Models.ViewModels;
using Survey.DAL.Models;
using System.Linq;

namespace Survey.Business.Mapping.DtoToView
{
    public static class ChkboxRadioToViewMap
    {
        public static ReceivedQuestionView MapToDto(Question item)
        {
            if (item == null)
                return null;

            var choiceList = new List<string>();

            if (item.QuestionChoices != null)
            {
                foreach (var choice in item.QuestionChoices.OrderBy(x => x.ChoiceOrder))
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