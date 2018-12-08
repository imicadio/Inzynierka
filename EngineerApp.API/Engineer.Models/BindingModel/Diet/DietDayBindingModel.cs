using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Engineer.Models.BindingModel.Diet
{
    public class DietDayBindingModel
    {
        [Required]
        [StringLength(40, ErrorMessage = "Dzień zawierać od 3 do 40 znaków", MinimumLength = 3)]
        public string Name { get; set; }

        public List<DietDetailBindingModel> DietDetailBindingModels { get; set; }

        public DietDayBindingModel()
        {
            DietDetailBindingModels = new List<DietDetailBindingModel>();
        }
    }
}
