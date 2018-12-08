using System;
using System.Collections.Generic;
using System.Text;

namespace Engineer.Models.BindingModel.Diet
{
    public class DietProductBindingModel
    {
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public string HomeMeasure { get; set; }
        public int DietDetailId { get; set; }
    }
}
