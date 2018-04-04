using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Survey.DAL.Models;

namespace Survey.Business.Models.ViewModels
{
    public class ReceivedQuestionView
    {
        public string title { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public bool isRequired { get; set; }
        public string maximumRateDescription { get; set; }
        public string mininumRateDescription { get; set; }

        //public virtual OptionGroupView OptionGroupView { get; set; }
        public List<string> choices { get; set; }
        //public Dictionary<string, string> Rows { get; set; }
        //public Dictionary<string, string> Columns { get; set; }
    }
}