using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.DAL.Models
{
    public class Question
    {
        public Guid Id { get; set; }
        public Guid PollId { get; set; }
        public int QuestionTypeId { get; set; }
        public int? QuestionOptionGroupId { get; set; }

        public string Title { get; set; }
        public string Name { get; set; }
        public bool AnswerRequired { get; set; }
        public int QuestionOrder { get; set; }
        //public QuestionType Type { get; set; }

        public virtual QuestionType QuestionType { get; set; }

        public virtual ICollection<QuestionOption> QuestionOptions { get; set; }

        public virtual QuestionOptionGroup QuestionOptionGroup { get; set; }

        private ICollection<QuestionChoice> _choices;

        public virtual ICollection<QuestionChoice> QuestionChoices
        {
            get { return _choices ?? (_choices = new Collection<QuestionChoice>()); }
            set { _choices = value; }
        }
    }
}
