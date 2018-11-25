using System;
using System.Collections.Generic;
using System.Text;

namespace Engineer.Models.Dto.Training
{
    public class TrainingsDto : BaseModelDto
    {
        public List<TrainingDto> Trainings { get; set; }
        public TrainingsDto()
        {
            Trainings = new List<TrainingDto>();
        }
    }
}
