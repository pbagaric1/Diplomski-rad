using System;
using System.Collections.Generic;
using Survey.Business.Models.ViewModels;
using Survey.DAL.Models;

namespace Survey.Business.Mapping
{
    public static class RadiogroupMap
    {
        public static RadiogroupQuestion MapToDto(ReceivedQuestionView item, int questionOrder)
        {
            if (item == null)
                return null;

            List<QuestionChoice> questionChoices = new List<QuestionChoice>();

            foreach (string choice in item.Choices)
            {
                QuestionChoice questionChoice = new QuestionChoice()
                {
                    Id = Guid.NewGuid(),
                    Choice = choice
                };
                questionChoices.Add(questionChoice);
            }

            return new RadiogroupQuestion()
            {
                Title = item.Title,
                IsRequired = item.isRequired,
                Choices = questionChoices,
                Id = Guid.NewGuid(),
                Type = QuestionType.Radiogroup,
                QuestionOrder = questionOrder
            };
        }
    }
}
