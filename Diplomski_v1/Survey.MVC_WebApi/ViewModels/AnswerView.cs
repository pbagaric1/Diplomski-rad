using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Survey.MVC_WebApi.ViewModels
{
    public class AnswerView
    {
        public Guid Id { get; set; }
        public Guid QuestionId { get; set; }
        public string Text { get; set; }

        //public virtual QuestionView Question { get; set; }
    }
}