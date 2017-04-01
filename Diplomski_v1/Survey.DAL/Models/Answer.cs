using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.DAL.Models
{
    public class Answer
    {
        public string Id { get; set; }
        public string QuestionId { get; set; }
        public string Name { get; set; }

        public virtual Question Question { get; set; }
    }
}
