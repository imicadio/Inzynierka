using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Engineer.Models.Models.Diets
{
    public class DietDetail
    {
        [Key]
        public int Id { get; set; }
        public string Meal { get; set; }
        public DateTime Hour { get; set; }
        public string Dish { get; set; }
        public string Recipe { get; set; }
        public string Comments { get; set; }
        public int DietDayId { get; set; }

        [ForeignKey(nameof(DietDayId))]
        public DietDay DietDay { get; set; }
        public ICollection<DietProduct> DietProducts { get; set; }
    }
}
