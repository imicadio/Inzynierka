using System;
using System.Collections.Generic;
using System.Text;

namespace Engineer.Models.Dto.Training
{
    public class TrainingDto : BaseModelDto
    {
        public int Id { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Name { get; set; }
        public string TrainerName { get; set; }
        public string UserName { get; set; }
        public List<TrainingDayDto> TrainingDays { get; set; }
        
        public TrainingDto()
        {
            TrainingDays = new List<TrainingDayDto>();
        }
    }
}
