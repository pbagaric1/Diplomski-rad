﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Business.Models.ViewModels
{
    public class DataView
    {
        public string name { get; set; }
        public decimal value { get; set; }
        public List<string> TextAnswers { get; set; }
    }
}