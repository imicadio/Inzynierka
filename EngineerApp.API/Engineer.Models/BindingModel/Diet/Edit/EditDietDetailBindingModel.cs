using System;
using System.Collections.Generic;
using System.Text;

namespace Engineer.Models.BindingModel.Diet.Edit
{
    public class EditDietDetailBindingModel
    {
        public string Meal { get; set; }
        public DateTime Hour { get; set; }
        public string Dish { get; set; }
        public string Recipe { get; set; }
        public string Comments { get; set; }
    }
}
