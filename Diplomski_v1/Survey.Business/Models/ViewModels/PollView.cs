using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Survey.DAL.Models;

namespace Survey.Business.Models.ViewModels
{
    public class PollView
    {
        public Guid Id { get; set; }
        public string title { get; set; }
        public string userId { get; set; }
        public string description { get; set; }
        public string organization { get; set; }
        public DateTime createdOn { get; set; }
        public string userName { get; set; }
        public bool visibility { get; set; }
        public DateTime? activityStartTime { get; set; }
        public DateTime? activityEndTime { get; set; }
        public int takesCount { get; set; }

        //public virtual AspNetUser AspNetUser { get; set; }
        //public ICollection<UserPoll> UserPolls { get; set; }
        private List<PageView> _pages;

        public List<PageView> pages
        {
            get { return _pages ?? (_pages = new List<PageView>()); }
            set { _pages = value; }
        }
    }
}
