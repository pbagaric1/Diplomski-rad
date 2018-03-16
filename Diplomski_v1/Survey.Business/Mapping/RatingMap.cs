﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Survey.Business.Models.QuestionTypeModels;
using Survey.Business.Models.ViewModels;
using Survey.DAL.Models;

namespace Survey.Business.Mapping
{
    public static class RatingMap
    {
        public static RatingQuestion MapToDto(ReceivedQuestionView item, int questionOrder)
        {
            if (item == null)
                return null;

            return new RatingQuestion()
            {
                Title = item.Title,
                IsRequired = item.isRequired,
                MaximumRateDescription = item.maximumRateDescription,
                MinimumRateDescription = item.minimumRateDescription,
                Id = Guid.NewGuid(),
                Type = QuestionType.Rating,
                QuestionOrder = questionOrder
            };
        }
    }
}
