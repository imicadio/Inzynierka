using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Engineer.Models.Models.Trainings
{
    public class TrainingDay
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Name { get; set; }
        //public Day Day { get; set; }

        public ICollection<ExerciseTraining> ExerciseTrainings { get; set; }

        // many-to-one User
        public int? TrainerId { get; set; }
        [ForeignKey("TrainerId")]
        public User TrainerPlan { get; set; }

        // many-to-one User
        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public User UserPlan { get; set; }
    }
}
