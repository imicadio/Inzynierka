using System;
using System.Collections.Generic;
using System.Text;

namespace Engineer.Models.Dto.Training
{
    public class ExerciseTrainingDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<SerieDto> Series { get; set; }

        public ExerciseTrainingDto()
        {
            Series = new List<SerieDto>();
        }
    }
}
