using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Model.Common
{
    public interface IAnswerDomain
    {
        Guid Id { get; set; }
        Guid QuestionId { get; set; }
        string Text { get; set; }

        //IQuestionDomain Question { get; set; }
    }
}
