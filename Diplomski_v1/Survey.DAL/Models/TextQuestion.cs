using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Survey.DAL.Models
{
    public class TextQuestion
    {
        public Guid Id { get; set; }
        public Guid PollId { get; set; }

        public string Title { get; set; }
        public bool IsRequired { get; set; }
        public int QuestionOrder { get; set; }
        public QuestionType Type { get; set; }
    }
}