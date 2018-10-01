using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Survey.DAL.Models
{
    public class Poll
    {
        public Guid Id { get; set; }
        public string AspNetUserId { get; set; }
        public string Organization { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public int TakesCount { get; set; }
        public DateTime CreatedOn { get; set; }

        //Survey not visible in listed surveys, but user that completed it should still be able to see it 
        public bool Visibility { get; set; }

        //Time period when survey is active and can be completed
        public DateTime? ActivityStartTime { get; set; }

        //Time period when survey is ending and can't be completed anymore
        public DateTime? ActivityEndTime { get; set; }

        public bool IsFinal { get; set; }

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
