using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Engineer.Models.Models.Trainings
{
    public class TypeOfTraining
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Exercise> Exercises { get; set; }
    }
}
