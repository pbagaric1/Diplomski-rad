using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Business.Models.ViewModels
{
    public class PageView
    {
        private List<ReceivedQuestionView> _questions;

        public List<ReceivedQuestionView> questions
        {
            get { return _questions ?? (_questions = new List<ReceivedQuestionView>()); }
            set { _questions = value; }
        }
    }
}
