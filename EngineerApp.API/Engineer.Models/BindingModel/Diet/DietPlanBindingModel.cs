using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Engineer.Models.BindingModel.Diet
{
    public class DietPlanBindingModel
    {
        [Required]
        [StringLength(40, ErrorMessage = "Nazwa treningu powinna zawierać od 3 do 40 znaków", MinimumLength = 3)]
        public string Name { get; set; }

        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }

        public List<DietDayBindingModel> DietDayBindingModels { get; set; }

        public DietPlanBindingModel()
        {
            DietDayBindingModels = new List<DietDayBindingModel>();
        }
    }
}
