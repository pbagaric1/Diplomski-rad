using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Survey.DAL.Models;

namespace Survey.DAL.Models
{
    public class RatingQuestion
    {
        public Guid Id { get; set; }
        public Guid PollId { get; set; }

        public string Title { get; set; }
        public bool IsRequired { get; set; }
        public int QuestionOrder { get; set; }
        public QuestionType Type { get; set; }

        public string MinimumRateDescription { get; set; }
        public string MaximumRateDescription { get; set; }
    }
}