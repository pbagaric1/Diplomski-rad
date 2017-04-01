using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.DAL.Models
{
    public class SurveyType
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Survey> Surveys { get; set; }
    }
}
