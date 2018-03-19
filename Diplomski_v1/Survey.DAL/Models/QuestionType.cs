using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Survey.DAL.Models
{
    //Input types of questions, eg. "text", "checkbox"
    public class QuestionType
    {
        public int Id { get; set; }
        public string Type { get; set; }
    }
}
