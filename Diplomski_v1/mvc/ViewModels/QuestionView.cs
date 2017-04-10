using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Survey.MVC_WebApi.ViewModels
{
    public class QuestionView
    {
        public Guid Id { get; set; }
        public Guid PollId { get; set; }
        public string Name { get; set; }

        public virtual PollView Poll { get; set; }
        public ICollection<AnswerView> Answers { get; set; }
    }
}