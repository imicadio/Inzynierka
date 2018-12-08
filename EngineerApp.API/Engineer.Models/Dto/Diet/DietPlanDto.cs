﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Engineer.Models.Dto.Diet
{
    public class DietPlanDto : BaseModelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<DietDayDto> DietDays { get; set; }

        public DietPlanDto()
        {
            DietDays = new List<DietDayDto>();
        }
    }
}
