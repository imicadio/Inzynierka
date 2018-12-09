using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Engineer.Models.BindingModel.Training.Edit
{
    public class EditExerciseTrainingBindingModel
    {
        public int Id { get; set; }
        //[Required]
        //[StringLength(40, ErrorMessage = "Nazwa ćwiczenia powinna zawierać od 3 do 40 znaków", MinimumLength = 3)]
        public string Name { get; set; }
        public string Description { get; set; }

        public List<EditSerieBindingModel> EditSerieBindingModels { get; set; }

        public EditExerciseTrainingBindingModel()
        {
            EditSerieBindingModels = new List<EditSerieBindingModel>();
        }

    }
}
