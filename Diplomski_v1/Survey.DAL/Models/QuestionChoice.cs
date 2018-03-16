using System;

namespace Survey.DAL.Models
{
    public class QuestionChoice
    {
        public Guid Id { get; set; }
        public Guid? RadiogroupQuestionId { get; set; }
        public Guid? CheckboxQuestionId { get; set; }

        public string Choice { get; set; }
    }
}
