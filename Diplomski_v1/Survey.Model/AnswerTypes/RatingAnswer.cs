using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.DAL.Models.AnswerTypes
{
    public class RatingAnswer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string MinimumRateDescription { get; set; }
        public string MaximumRateDescription { get; set; }
    }
}
