﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Survey.DAL.Models;

namespace Survey.Business.Models.ViewModels
{
    public class RadiogroupQuestionView
    {
        public Guid Id { get; set; }
        public Guid PollId { get; set; }

        public string Title { get; set; }
        public bool IsRequired { get; set; }
        public int QuestionOrder { get; set; }
        public QuestionType Type { get; set; }

        private ICollection<QuestionChoice> _choices;

        public virtual ICollection<QuestionChoice> Choices
        {
            get { return _choices ?? (_choices = new Collection<QuestionChoice>()); }
            set { _choices = value; }
        }
    }
}