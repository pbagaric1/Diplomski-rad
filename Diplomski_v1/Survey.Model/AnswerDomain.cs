using Survey.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Model
{
    public class AnswerDomain : IAnswerDomain
    {
        public Guid Id { get; set; }
        public Guid QuestionId { get; set; }
        public string Name { get; set; }

       // public virtual IQuestionDomain Question { get; set; }
    }
}
