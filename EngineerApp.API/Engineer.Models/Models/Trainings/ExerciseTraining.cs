using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Engineer.Models.Models.Trainings
{
    public class ExerciseTraining
    {
        [Key]
        public int Id { get; set; }
        public int TrainingDayId { get; set; }
        //public int ExerciseId { get; set; }
        public string Description { get; set; }

        //[ForeignKey(nameof(ExerciseId))]
        //public Exercise Exercise { get; set; }

        [ForeignKey(nameof(TrainingDayId))]
        public TrainingDay TrainingDay { get; set; }

        public ICollection<Serie> Series { get; set; }
    }
}
