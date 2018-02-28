using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.DAL.Models.QuestionTypes
{
    public class QuestionTypeRating
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string MinRateDescription { get; set; }
        public string MaxRateDescription { get; set; }
    }
}
