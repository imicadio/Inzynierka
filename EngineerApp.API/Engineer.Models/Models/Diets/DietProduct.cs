using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Engineer.Models.Models.Diets
{
    public class DietProduct
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public string HomeMeasure { get; set; }
        public int DietDetailId { get; set; }

        [ForeignKey(nameof(DietDetailId))]
        public DietDetail DietDetail { get; set; }        

    }
}
