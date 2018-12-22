using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Engineer.Models.BindingModel.Training
{
    public class TrainingPlanBindingModel
    {
        [Required]
        [StringLength(40, ErrorMessage = "Nazwa treningu powinna zawierać od 3 do 40 znaków", MinimumLength = 3)]
        public string Name { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }

        public List<TrainingDayBindingModel> TrainingDayBindingModels { get; set; }

        public TrainingPlanBindingModel()
        {
            TrainingDayBindingModels = new List<TrainingDayBindingModel>();
        }
    }
}
