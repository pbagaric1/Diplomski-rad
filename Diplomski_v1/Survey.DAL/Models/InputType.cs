using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.DAL.Models
{
    //Input types of questions, eg. "text", "checkbox"
    public class InputType
    {
        public Guid Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}
