using System;
using System.Collections.Generic;
using System.Text;

namespace Engineer.Models.Dto.Survey
{
    public class SurveyForSearchDto : BaseModelDto
    {
        public int Id { get; set; }
        public double Size { get; set; }
        public DateTime DateAdded { get; set; }
        public int TrainerId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}
