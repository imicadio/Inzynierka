using System;
using System.Collections.Generic;
using System.Text;

namespace Engineer.Models.Dto.Diet
{
    public class DietDetailDto
    {
        public int Id { get; set; }
        public string Meal { get; set; }
        public DateTime Hour { get; set; }
        public string Dish { get; set; }
        public string Recipe { get; set; }
        public string Comments { get; set; }

        public List<DietProductDto> DietProducts { get; set; }

        public DietDetailDto()
        {
            DietProducts = new List<DietProductDto>();
        }
    }
}
