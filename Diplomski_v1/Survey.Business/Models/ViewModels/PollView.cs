using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Survey.DAL.Models;

namespace Survey.Business.Models.ViewModels
{
    public class PollView
    {

        public string Name { get; set; }
        public string UserId { get; set; }
        public string Instructions { get; set; }
        public string Organization { get; set; }
        public DateTime CreatedOn { get; set; }

        //public virtual AspNetUser AspNetUser { get; set; }
        //public ICollection<UserPoll> UserPolls { get; set; }
        public ICollection<QuestionView> Questions { get; set; }
    }
}