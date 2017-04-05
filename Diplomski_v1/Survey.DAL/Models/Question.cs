﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.DAL.Models
{
    public class Question
    {
        public Guid Id { get; set; }
        public Guid PollId { get; set; }
        public string Name { get; set; }

        public virtual Poll Poll { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}