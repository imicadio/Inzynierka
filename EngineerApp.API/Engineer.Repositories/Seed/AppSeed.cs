using System;
using System.Collections.Generic;
using System.Text;

namespace Engineer.Repositories.Seed
{
    public static class AppSeed
    {
        public static void SeddDataBase(this DataContext context)
        {
            SeedRole.Seed(context);
            SeedSurvey.Seed(context);
            SeedTraining.Seed(context);
            SeedDiet.Seed(context);
        }
    }
}
