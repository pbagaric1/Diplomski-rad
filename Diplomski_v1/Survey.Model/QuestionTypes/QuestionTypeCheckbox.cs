using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Survey.DAL.Models.AnswerTypes;

namespace Survey.DAL.Models.QuestionTypes
{
    public class QuestionTypeCheckbox
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool IsRequired { get; set; }

        public virtual IEnumerable<CheckboxAnswer> CheckboxAnswers { get; set; }
    }
}
