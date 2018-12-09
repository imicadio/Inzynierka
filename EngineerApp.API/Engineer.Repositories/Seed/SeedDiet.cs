using Engineer.Models.Models.Diets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engineer.Repositories.Seed
{
    public static class SeedDiet
    {
        public static void Seed(DataContext context)
        {
            if (!context.DietPlans.Any())
            {
                context.DietPlans.AddRange(new DietPlan[]
                {
                    new DietPlan(){ Name = "Kuchnia Joanny", TrainerDietId = 11, UserDietId = 1},
                    new DietPlan(){ Name = "Kuchnia Wrzoska", TrainerDietId = 11, UserDietId = 2}
                });
                context.SaveChanges();
            }

            if (!context.DietDays.Any())
            {
                var diet1 = context.DietPlans.SingleOrDefault(x => x.Name.Equals("Kuchnia Joanny"));
                var diet2 = context.DietPlans.SingleOrDefault(x => x.Name.Equals("Kuchnia Wrzoska"));

                context.DietDays.AddRange(new DietDay[]
                {
                    new DietDay(){ Name = "Poniedziałek", DietPlan = diet1, DietDetails = new DietDetail[]
                        {
                            new DietDetail(){ Meal = "Śniadanie", Hour = DateTime.Now, Dish = "Omlet z dżemem + kawa", Recipe = "Białka ubijamy dodajemy żółtka, mąkę i odrobinę wody, mieszamy. Wylewamy na rozgrzaną i naoliwiona patelnie. Gotowy omlet smarujemy dżemem.",
                                DietProducts = new DietProduct[]
                                {
                                    new DietProduct(){ Name = "Jaja", Quantity = 120, HomeMeasure = "2 sztuki"},
                                    new DietProduct(){ Name = "Mąka razowa", Quantity = 60, HomeMeasure = "2 łyżki"},
                                    new DietProduct(){ Name = "Dżem truskawkowy", Quantity = 20, HomeMeasure = "1 łyżka"},
                                    new DietProduct(){ Name = "Kawa czarna bez cukru", Quantity = 120, HomeMeasure = "1 filiżanka"},
                                    new DietProduct(){ Name = "Olej rzepakowy", Quantity = 5, HomeMeasure = "1 łyżeczka"}
                                }
                            }
                        }
                    }
                });
                context.SaveChanges();
            }
        }
    }
}
