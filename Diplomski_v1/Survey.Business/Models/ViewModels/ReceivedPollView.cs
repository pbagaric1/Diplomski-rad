using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using Survey.DAL.Models;

namespace Survey.Business.Models.ViewModels
{
    public class ReceivedPollView
    {
        public string Name { get; set; }
        public string UserId { get; set; }
        public string Instructions { get; set; }
        public string Organization { get; set; }
        public DateTime CreatedOn { get; set; }

        //public virtual AspNetUser AspNetUser { get; set; }
        //public ICollection<UserPoll> UserPolls { get; set; }

        private ICollection<ReceivedQuestionView> _questions;

        public virtual ICollection<ReceivedQuestionView> Questions
        {
            get { return _questions ?? (_questions = new Collection<ReceivedQuestionView>()); }
            set { _questions = value; }
        }
    }
}