using System;
using System.Collections.Generic;
using System.Text;

namespace Engineer.Models.BindingModel
{
    public class SearchBindingModel
    {
        public int PageNumber { get; set; } = 1;
        public int Limit { get; set; } = 25;
        public string Sort { get; set; } = "DateStart";
        public string Query { get; set; } = "";
        public bool Ascending { get; set; } = true;
        public DateTime? PresentDay { get; set; } = null;
        public DateTime? EndDay { get; set; } = null;
    }
}
