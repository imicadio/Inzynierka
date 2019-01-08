using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Engineer.Models.Models.Diets
{
    public class DietPlan
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string TrainerName { get; set; }
        public string UserName { get; set; }

        public ICollection<DietDay> DietDays { get; set; }

        // many-to-one User
        public int? UserDietId { get; set; }
        [ForeignKey("UserDietId")]
        public User UserDiet { get; set; }

        // many-to-one User
        public int? TrainerDietId { get; set; }
        [ForeignKey("TrainerDietId")]
        public User TrainerDiet { get; set; }
    }
}
