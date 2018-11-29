using System;
using System.Collections.Generic;
using System.Text;

namespace Engineer.Models.Dto.Training
{
    public class TrainingDayDto
    {
        public string Day { get; set; }
        public string TypeOfTraining { get; set; }

        public List<ExerciseTrainingDto> ExerciseTrainings { get; set; }

        public TrainingDayDto()
        {
            ExerciseTrainings = new List<ExerciseTrainingDto>();
        }
    }
}
