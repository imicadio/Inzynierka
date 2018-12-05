using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Engineer.Models.Models
{
    public class Pupil
    {
        public int Id { get; set; }                

        public int? TrainerId { get; set; }
        [ForeignKey("TrainerId")]
        public User TrainerPupil { get; set; }

        public int? PupilId { get; set; }
        [ForeignKey("PupilId")]
        public User PupilTrainer { get; set; }
    }
}
