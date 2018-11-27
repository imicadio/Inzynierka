using Engineer.Models.Models.Trainings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Engineer.Models.Dto.Training
{
    public class AddTrainingBindingModel
    {
        //public DateTime DateStart { get; set; }
        //public DateTime DateEnd { get; set; }

        [Required]
        [StringLength(40, ErrorMessage = "Nazwa treningu powinna zawierać od 3 do 40 znaków", MinimumLength = 3)]
        public string Name { get; set; }

        public List<AddExerciseTrainingBindingModel> ExerciseTrainingBindingModels { get; set; }
    }
}
