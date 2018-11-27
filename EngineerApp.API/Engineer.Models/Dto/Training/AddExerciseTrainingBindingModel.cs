using System;
using System.Collections.Generic;
using System.Text;

namespace Engineer.Models.Dto.Training
{
    public class AddExerciseTrainingBindingModel
    {
        public string Description { get; set; }

        public List<AddSerieBindingModel> SerieBindingModels { get; set; }
    }
}
