using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Survey.DAL.Models.AnswerTypes;

namespace Survey.DAL.Models.QuestionTypes
{
    public class QuestionTypeRadiogroup
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool IsRequired { get; set; }

        public virtual IEnumerable<RadioAnswer> RadioAnswers { get; set; }
    }
}
