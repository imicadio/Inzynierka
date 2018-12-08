using System;
using System.Collections.Generic;
using System.Text;

namespace Engineer.Models.Dto.Diet
{
    public class DietsDto : BaseModelDto
    {
        public int Id { get; set; }
        public List<DietPlanDto> Diets { get; set; }
        public DietsDto()
        {
            Diets = new List<DietPlanDto>();
        }
    }
}
