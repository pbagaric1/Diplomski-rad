using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.DAL.Models
{
    public class Question
    {
        public Guid Id { get; set; }
        public Guid PollId { get; set; }
        public Guid InputTypeId { get; set; }
        public Guid OptionGroupId { get; set; }

        public string Title { get; set; }
        public bool AnswerRequired { get; set; }
        public int QuestionOrder { get; set; }

        public virtual Poll Poll { get; set; }
        public virtual InputType InputType { get; set; }
        public virtual OptionGroup OptionGroup { get; set; }
        public ICollection<QuestionOption> QuestionOptions { get; set; }
    }
}
