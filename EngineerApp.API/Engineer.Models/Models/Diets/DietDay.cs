using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Engineer.Models.Models.Diets
{
    public class DietDay
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int DietPlanId { get; set; }

        [ForeignKey(nameof(DietPlanId))]
        public DietPlan DietPlan { get; set; }

        public ICollection<DietDetail> DietDetails { get; set; }
    }
}
