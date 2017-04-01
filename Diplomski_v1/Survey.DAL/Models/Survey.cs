using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.DAL.Models
{
    public class Survey
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string SurveyTypeId { get; set; }
        public string Name { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
        public virtual SurveyType SurveyType { get; set; }
        public ICollection <Question> Questions { get; set; }
    }
}
