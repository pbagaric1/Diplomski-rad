using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.DAL.Models
{
    public class Question
    {
        public string Id { get; set; }
        public string SurveyId { get; set; }
        public string Name { get; set; }

        public virtual Survey Survey { get; set; }
        public ICollection <Answer> Answers { get; set; }
    }
}
