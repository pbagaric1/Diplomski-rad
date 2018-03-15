using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Survey.Business.Models.QuestionTypeModels
{
    public class RatingTypeModel
    {
        public string Title { get; set; }
        public bool isRequired { get; set; }

        public string minimumRateDescription { get; set; }
        public string maximumRateDescription { get; set; }
    }
}