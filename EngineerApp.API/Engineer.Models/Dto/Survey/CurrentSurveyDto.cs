using System;
using System.Collections.Generic;
using System.Text;

namespace Engineer.Models.Dto.Survey
{
    public class CurrentSurveyDto : BaseModelDto
    {
        public int Id { get; set; }
        public List<SurveyForSearchDto> currentSurvey { get; set; }
        public CurrentSurveyDto()
        {
            currentSurvey = new List<SurveyForSearchDto>();
        }
    }
}
