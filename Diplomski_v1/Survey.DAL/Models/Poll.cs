using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Survey.DAL.Models
{
    public class Poll
    {
        public Guid Id { get; set; }
        public string AspNetUserId { get; set; }
        public Guid OrganizationId { get; set; }

        public string Name { get; set; }
        public string Instructions { get; set; }
        public DateTime CreatedOn { get; set; }

        //public ICollection<UserPoll> UserPolls { get; set; }
        private ICollection<Question> _questions;

        public virtual ICollection<Question> Questions
        {
            get { return _questions ?? (_questions = new Collection<Question>()); }
            set { _questions = value; }
        }

        public virtual AspNetUser AspNetUser { get; set; }
    }
}
