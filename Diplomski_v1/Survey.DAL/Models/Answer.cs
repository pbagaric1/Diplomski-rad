using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.DAL.Models
{
    //Answer that user responded with
    public class Answer
    {
        public Guid Id { get; set; }
        public Guid? QuestionOptionId { get; set; }
        public Guid QuestionId { get; set; }
        public string AspNetUserId { get; set; }

        public string Text { get; set; }

        public virtual Question Question { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual QuestionOption QuestionOption { get; set; }
    }
}
