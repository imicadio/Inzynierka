using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Engineer.Models.BindingModel.Training.Edit
{
    public class EditTrainingDayBindingModel
    {
        public int Id { get; set; }
        //[Required]
        //[StringLength(40, ErrorMessage = "Musisz podać dzień", MinimumLength = 3)]
        public string Day { get; set; }
        //[Required]
        //[StringLength(40, ErrorMessage = "Wymagany jest typ treningu", MinimumLength = 3)]
        public string TypeOfTraining { get; set; }

        public List<EditExerciseTrainingBindingModel> EditExerciseTrainingBindingModels { get; set; }

        public EditTrainingDayBindingModel()
        {
            EditExerciseTrainingBindingModels = new List<EditExerciseTrainingBindingModel>();
        }
    }
}
