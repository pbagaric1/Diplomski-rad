using System;
using System.Collections.Generic;

namespace Survey.DAL.Models
{
    public class QuestionChoice
    {
        public Guid Id { get; set; }
        public Guid QuestionId { get; set; }
        //public Guid QuestionOptionGroupId { get; set; }
        public string Name { get; set; }
        public int ChoiceOrder { get; set; }

    //public ICollection<QuestionOption> QuestionOptions { get; set; }
    //public virtual QuestionOptionGroup QuestionOptionGroup { get; set; }
  }
}
