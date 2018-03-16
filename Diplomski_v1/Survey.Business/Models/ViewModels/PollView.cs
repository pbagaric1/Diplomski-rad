﻿using System;
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
        public string Name { get; set; }
        public string UserId { get; set; }
        public string Instructions { get; set; }
        public string Organization { get; set; }
        public DateTime CreatedOn { get; set; }

        //public virtual AspNetUser AspNetUser { get; set; }
        //public ICollection<UserPoll> UserPolls { get; set; }
        private List<PageView> _pages;

        public List<PageView> Pages
        {
            get { return _pages ?? (_pages = new List<PageView>()); }
            set { _pages = value; }
        }
    }
}
