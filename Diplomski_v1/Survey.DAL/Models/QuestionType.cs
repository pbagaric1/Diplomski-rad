using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.DAL.Models
{
    //Input types of questions, eg. "text", "checkbox"
    public enum QuestionType
    {
        Text = 0,
        Checkbox = 1,
        Radiogroup = 2,
        Comment = 3,
        Rating = 4
    }
}
