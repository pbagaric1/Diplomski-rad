using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.DAL.Models.QuestionTypes
{
    public class QuestionTypeText
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool IsRequired { get; set; }
    }
}
