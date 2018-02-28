using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.DAL.Models
{
    //If answer to a question is in between two values
    public class OptionGroup
    {
        public Guid Id { get; set; }
        public string MinValue { get; set; }
        public string MaxValue { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}