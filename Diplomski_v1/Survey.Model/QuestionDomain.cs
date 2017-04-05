using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Survey.Model.Common;

namespace Survey.Model
{
    public class QuestionDomain : IQuestionDomain
    {
        public Guid Id { get; set; }
        public Guid PollId { get; set; }
        public string Name { get; set; }

        public virtual IPollDomain Poll { get; set; }
        public ICollection <IAnswerDomain> Answers { get; set; }
    }
}
