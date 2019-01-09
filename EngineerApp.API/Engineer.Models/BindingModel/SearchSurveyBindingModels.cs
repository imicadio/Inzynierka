using System;
using System.Collections.Generic;
using System.Text;

namespace Engineer.Models.BindingModel
{
    public class SearchSurveyBindingModels
    {
        public int PageNumber { get; set; } = 1;
        public int Limit { get; set; } = 25;
        public string Sort { get; set; } = "DateAdded";
        public string Query { get; set; } = "";
        public bool Ascending { get; set; } = true;
    }
}
