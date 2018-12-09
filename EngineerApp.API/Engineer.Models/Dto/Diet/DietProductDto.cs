using System;
using System.Collections.Generic;
using System.Text;

namespace Engineer.Models.Dto.Diet
{
    public class DietProductDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public string HomeMeasure { get; set; }        
    }
}
