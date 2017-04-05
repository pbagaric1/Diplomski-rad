using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Model.Common
{
    public interface IQuestionDomain
    {
        Guid Id { get; set; }
        Guid PollId { get; set; }
        string Name { get; set; }

        IPollDomain Poll { get; set; }
        ICollection <IAnswerDomain> Answers { get; set; }
    }
}
