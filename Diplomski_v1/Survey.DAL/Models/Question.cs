using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.DAL.Models
{
    public abstract class Question
    {
        public Guid Id { get; set; }
        public Guid PollId { get; set; }

        public string Title { get; set; }
        public bool IsRequired { get; set; }
        public int QuestionOrder { get; set; }
        public QuestionType Type { get; set; }

        //public virtual Poll Poll { get; set; }

        //private ICollection<QuestionChoice> _questionChoices;
        //public virtual ICollection<QuestionChoice> QuestionChoices
        //{
        //    get { return _questionChoices ?? (_questionChoices = new Collection<QuestionChoice>()); }
        //    set { _questionChoices = value; }
        //}
    }
}
