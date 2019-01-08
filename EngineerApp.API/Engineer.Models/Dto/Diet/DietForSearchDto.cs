using System;
using System.Collections.Generic;
using System.Text;

namespace Engineer.Models.Dto.Diet
{
    public class DietForSearchDto : BaseModelDto
    {
        public int Id { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Name { get; set; }
        public string TrainerName { get; set; }
        public string UserName { get; set; }
    }
}
