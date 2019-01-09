using Engineer.Models.Models.Survey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engineer.Repositories.Seed
{
    public static class SeedSurvey
    {
        public static void Seed(DataContext context)
        {
            if (!context.Surveys.Any())
            {
                context.Surveys.AddRange(new Surveyy[]
                {
                    new Surveyy(){ TrainerId = 11, UserId = 1},
                    new Surveyy(){ TrainerId = 11, UserId = 2},
                    new Surveyy(){ TrainerId = 11, UserId = 3}
                });
            }
        }
    }
}
