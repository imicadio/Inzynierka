using System;
using System.Collections.Generic;
using System.Text;

namespace Engineer.Models.BindingModel.Training
{
    public class ExerciseTrainingBindingModel
    {
        public string Description { get; set; }

        public List<SerieBindingModel> SerieBindingModels { get; set; }

        public ExerciseTrainingBindingModel()
        {
            SerieBindingModels = new List<SerieBindingModel>();
        }
    }
}
