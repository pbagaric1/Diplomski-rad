using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.DAL.Models
{
    //All possible options related to a single question
    public class QuestionChoice
    {
        public Guid Id { get; set; }
        public Guid QuestionId { get; set; }
        public string Name { get; set; }

        //public ICollection<QuestionOption> QuestionOptions { get; set; }
        public virtual Question Question { get; set; }
    }
}
