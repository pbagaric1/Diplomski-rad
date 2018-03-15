using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Survey.Business.Models.QuestionTypeModels
{
    public class RadiogroupTypeModel
    {
        public string Title { get; set; }
        public bool isRequired { get; set; }
        public List<string> Choices { get; set; }
    }
}