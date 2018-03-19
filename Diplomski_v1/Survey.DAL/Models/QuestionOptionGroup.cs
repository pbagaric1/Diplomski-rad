using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.DAL.Models
{
    public class QuestionOptionGroup
    {
        
        public int Id { get; set; }
        public string MinimumRateDescription { get; set; }
        public string MaximumRateDescription { get; set; }

        //public ICollection<Question> Questions { get; set; }
        //public ICollection<QuestionChoice> QuestionChoices { get; set; }
    }
}
