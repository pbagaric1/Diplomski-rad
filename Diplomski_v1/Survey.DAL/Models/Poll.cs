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

        //public ICollection<TextQuestion> TextQuestions { get; set; }
        //public ICollection<RadiogroupQuestion> RadiogroupQuestions { get; set; }
        //public ICollection<CheckboxQuestion> CheckboxQuestions { get; set; }
        //public ICollection<RatingQuestion> RatingQuestions { get; set; }

        private ICollection<TextQuestion> _textQuestions;

        public virtual ICollection<TextQuestion> TextQuestions
        {
            get { return _textQuestions ?? (_textQuestions = new Collection<TextQuestion>()); }
            set { _textQuestions = value; }
        }

        private ICollection<RadiogroupQuestion> _radiogroupQuestions;

        public virtual ICollection<RadiogroupQuestion> RadiogroupQuestions
        {
            get { return _radiogroupQuestions ?? (_radiogroupQuestions = new Collection<RadiogroupQuestion>()); }
            set { _radiogroupQuestions = value; }
        }

        private ICollection<CheckboxQuestion> _checkboxQuestions;

        public virtual ICollection<CheckboxQuestion> CheckboxQuestions
        {
            get { return _checkboxQuestions ?? (_checkboxQuestions = new Collection<CheckboxQuestion>()); }
            set { _checkboxQuestions = value; }
        }

        private ICollection<RatingQuestion> _ratingQuestions;

        public virtual ICollection<RatingQuestion> RatingQuestions
        {
            get { return _ratingQuestions ?? (_ratingQuestions = new Collection<RatingQuestion>()); }
            set { _ratingQuestions = value; }
        }


    }
}
