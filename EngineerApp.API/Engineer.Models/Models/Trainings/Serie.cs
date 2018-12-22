using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Engineer.Models.Models.Trainings
{
    public class Serie
    {
        [Key]
        public int Id { get; set; }        
        public int SerialNumber { get; set; }   // numer serii
        public int Number { get; set; }         // ilosc powtorzen
        public string Unit { get; set; }           // jednostka - powt., min.

        public int ExerciseTrainingId { get; set; }
        [ForeignKey(nameof(ExerciseTrainingId))]
        public ExerciseTraining ExerciseTraining { get; set; }
    }
}
