using System;
using System.Collections.Generic;
using System.Text;

namespace Engineer.Models.Dto.Diet
{
    public class DietDayDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<DietDetailDto> DietDetails { get; set; }

        public DietDayDto()
        {
            DietDetails = new List<DietDetailDto>();
        }
    }
}
