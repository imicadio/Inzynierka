using Engineer.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engineer.Repositories.Seed
{
    public static class SeedRole
    {
        public static void Seed(DataContext context)
        {
            if (!context.Pupils.Any())
            {
                context.Pupils.AddRange(new Pupil[]
                {
                    new Pupil(){ TrainerId = 11, PupilId = 1},
                    new Pupil(){ TrainerId = 11, PupilId = 2},
                    new Pupil(){ TrainerId = 11, PupilId = 3}
                });
            }
        }
    }
}
