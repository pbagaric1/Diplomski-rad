using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.DAL.Models
{
    //Table to connect Question and QuestionChoice
    public class QuestionOption
    {
        public Guid Id { get; set; }
        public Guid QuestionId { get; set; }
        public Guid QuestionChoiceId { get; set; }

        //public ICollection<Answer> Answers { get; set; }
        public virtual QuestionChoice QuestionChoice { get; set; }
        public virtual Question Question { get; set; }

    }
}
