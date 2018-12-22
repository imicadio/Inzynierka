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
        public string Day { get; set; }        
        public string TypeOfTraining { get; set; }

        public int TrainingPlanId { get; set; }
        [ForeignKey(nameof(TrainingPlanId))]
        public TrainingPlan TrainingPlan { get; set; }

        public ICollection<ExerciseTraining> ExerciseTrainings { get; set; }
    }
}
