﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Engineer.Models.Dto.Training
{
    public class TrainingDto : BaseModelDto
    {
        public int Id { get; set; }
        //public DateTime DateStart { get; set; }
        //public DateTime DateEnd { get; set; }
        public string Name { get; set; }
        public List<ExerciseTrainingDto> ExerciseTrainings { get; set; }
        
        public TrainingDto()
        {
            ExerciseTrainings = new List<ExerciseTrainingDto>();
        }
    }
}
