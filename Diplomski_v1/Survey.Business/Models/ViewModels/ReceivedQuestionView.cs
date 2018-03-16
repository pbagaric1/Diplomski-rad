using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Survey.DAL.Models;

namespace Survey.Business.Models.ViewModels
{
    public class ReceivedQuestionView
    {
        public string Title { get; set; }
        public string Type { get; set; }
        public bool isRequired { get; set; }
        public string maximumRateDescription { get; set; }
        public string minimumRateDescription { get; set; }

        //public virtual OptionGroupView OptionGroupView { get; set; }
        public List<string> Choices { get; set; }
        //public Dictionary<string, string> Rows { get; set; }
        //public Dictionary<string, string> Columns { get; set; }
    }
}