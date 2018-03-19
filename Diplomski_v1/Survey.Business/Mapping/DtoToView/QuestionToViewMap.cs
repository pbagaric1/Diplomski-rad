﻿using System;
using System.Collections.Generic;
using Survey.Business.Models.ViewModels;
using Survey.DAL.Models;

namespace Survey.Business.Mapping.DtoToView
{
    public static class QuestionToViewMap
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
                title = item.Title,
                choices = choiceList,
                type = item.QuestionType.Type,
                isRequired = item.AnswerRequired
            };
        }
    }
}