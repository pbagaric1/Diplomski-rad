﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Survey.DAL.Models;

namespace Survey.DAL.Models
{
    public class CheckboxTypeModel : Question
    {
        public List<string> Choices { get; set; }
        
    }
}