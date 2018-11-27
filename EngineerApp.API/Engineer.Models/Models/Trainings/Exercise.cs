using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Engineer.Models.Models.Trainings
{
    public class Exercise
    {
        [Key]
        public int Id { get; set; }
        public int TypeOfTrainingId { get; set; }
        public string Name { get; set; }

        [ForeignKey(nameof(TypeOfTrainingId))]
        public TypeOfTraining TypeOfTraining { get; set; }
        
        //public ICollection<ExerciseTraining> ExerciseTrainings { get; set; }
    }
}
