using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Survey.DAL.Models;

namespace Survey.Business.Models.QuestionTypeModels
{
    public class CheckboxTypeModel
    {
        public string Title { get; set; }
        public bool isRequired { get; set; }
        public List<string> Choices { get; set; }
        //public ICollection<QuestionChoice> Choices { get; set; }
    }
}