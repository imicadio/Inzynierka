﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Engineer.Models.BindingModel.Survey
{
    public class SurveyBindingModel
    {
        [Required]
        public double Size { get; set; }        
    }
}
