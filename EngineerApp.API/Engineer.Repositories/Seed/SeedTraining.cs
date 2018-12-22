using Engineer.Models.Models.Trainings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engineer.Repositories.Seed
{
    public static class SeedTraining
    {
        public static void Seed(DataContext context)
        {
            if (!context.TrainingPlans.Any())
            {
                context.TrainingPlans.AddRange(new TrainingPlan[]{
                    new TrainingPlan(){ Name = "Projekt Spartan", TrainerId = 11, UserId = 1 },
                    new TrainingPlan(){ Name = "Projekt Gladiator", TrainerId = 11, UserId = 2 },
                    new TrainingPlan(){ Name = "300", TrainerId = 11, UserId = 1 },
                    new TrainingPlan(){ Name = "Brad Pitt", TrainerId = 11, UserId = 3 }
                });
                context.SaveChanges();
            } // TrainingPlans

            if (!context.TrainingDays.Any())
            {
                var training1 = context.TrainingPlans.SingleOrDefault(x => x.Name.Equals("Projekt Spartan"));
                var training2 = context.TrainingPlans.SingleOrDefault(x => x.Name.Equals("Projekt Gladiator"));
                var training3 = context.TrainingPlans.SingleOrDefault(x => x.Name.Equals("300"));
                var training4 = context.TrainingPlans.SingleOrDefault(x => x.Name.Equals("Brad Pitt"));

                context.TrainingDays.AddRange(new TrainingDay[]{
                    new TrainingDay(){ Day = "Poniedziałek", TypeOfTraining = "Siłowy", TrainingPlanId = training1.Id,
                        ExerciseTrainings = new ExerciseTraining[]
                        {
                            new ExerciseTraining(){ Name = "Przysiady", Series = new Serie[]
                                {
                                    new Serie(){ Number = 1, SerialNumber = 15, Unit = "powt."},
                                    new Serie(){ Number = 2, SerialNumber = 12, Unit = "powt."},
                                    new Serie(){ Number = 3, SerialNumber = 10, Unit = "powt."},
                                    new Serie(){ Number = 4, SerialNumber = 8, Unit = "powt."}
                                }
                            },
                            new ExerciseTraining(){ Name = "Martwy ciąg", Series = new Serie[]
                                {
                                    new Serie(){ Number = 1, SerialNumber = 12, Unit = "powt."},
                                    new Serie(){ Number = 2, SerialNumber = 10, Unit = "powt."},
                                    new Serie(){ Number = 3, SerialNumber = 10, Unit = "powt."},
                                    new Serie(){ Number = 4, SerialNumber = 8, Unit = "powt."}
                                }
                            },
                            new ExerciseTraining(){ Name = "Wyciskanie na ławce skośnej", Series = new Serie[]
                                {
                                    new Serie(){ Number = 1, SerialNumber = 12, Unit = "powt."},
                                    new Serie(){ Number = 2, SerialNumber = 10, Unit = "powt."},
                                    new Serie(){ Number = 3, SerialNumber = 10, Unit = "powt."},
                                    new Serie(){ Number = 4, SerialNumber = 8, Unit = "powt."}
                                }
                            },
                            new ExerciseTraining(){ Name = "Wyciskanie żołnierskie", Series = new Serie[]
                                {
                                    new Serie(){ Number = 1, SerialNumber = 12, Unit = "powt."},
                                    new Serie(){ Number = 2, SerialNumber = 10, Unit = "powt."},
                                    new Serie(){ Number = 3, SerialNumber = 10, Unit = "powt."}
                                }
                            },
                            new ExerciseTraining(){ Name = "Allahy", Series = new Serie[]
                                {
                                    new Serie(){ Number = 1, SerialNumber = 15, Unit = "powt."},
                                    new Serie(){ Number = 2, SerialNumber = 15, Unit = "powt."},
                                    new Serie(){ Number = 3, SerialNumber = 15, Unit = "powt."},
                                    new Serie(){ Number = 4, SerialNumber = 15, Unit = "powt."}
                                }
                            }
                        }
                    },
                    new TrainingDay(){ Day = "Wtorek", TypeOfTraining = "Cardio", TrainingPlanId = training1.Id,
                        ExerciseTrainings = new ExerciseTraining[]
                        {
                            new ExerciseTraining(){ Name = "Rowerek", Series = new Serie[]
                                {
                                    new Serie(){ Number = 1, SerialNumber = 30, Unit = "min."}
                                }
                            }
                        }
                    },
                    new TrainingDay(){ Day = "Środa", TypeOfTraining = "Siłowy", TrainingPlanId = training1.Id,
                        ExerciseTrainings = new ExerciseTraining[]
                        {
                            new ExerciseTraining(){ Name = "Przysiady", Series = new Serie[]
                                {
                                    new Serie(){ Number = 1, SerialNumber = 15, Unit = "powt."},
                                    new Serie(){ Number = 2, SerialNumber = 12, Unit = "powt."},
                                    new Serie(){ Number = 3, SerialNumber = 10, Unit = "powt."},
                                    new Serie(){ Number = 4, SerialNumber = 8, Unit = "powt."}
                                }
                            },
                            new ExerciseTraining(){ Name = "Martwy ciąg", Series = new Serie[]
                                {
                                    new Serie(){ Number = 1, SerialNumber = 12, Unit = "powt."},
                                    new Serie(){ Number = 2, SerialNumber = 10, Unit = "powt."},
                                    new Serie(){ Number = 3, SerialNumber = 10, Unit = "powt."},
                                    new Serie(){ Number = 4, SerialNumber = 8, Unit = "powt."}
                                }
                            },
                            new ExerciseTraining(){ Name = "Wyciskanie na ławce skośnej", Series = new Serie[]
                                {
                                    new Serie(){ Number = 1, SerialNumber = 12, Unit = "powt."},
                                    new Serie(){ Number = 2, SerialNumber = 10, Unit = "powt."},
                                    new Serie(){ Number = 3, SerialNumber = 10, Unit = "powt."},
                                    new Serie(){ Number = 4, SerialNumber = 8, Unit = "powt."}
                                }
                            },
                            new ExerciseTraining(){ Name = "Wyciskanie żołnierskie", Series = new Serie[]
                                {
                                    new Serie(){ Number = 1, SerialNumber = 12, Unit = "powt."},
                                    new Serie(){ Number = 2, SerialNumber = 10, Unit = "powt."},
                                    new Serie(){ Number = 3, SerialNumber = 10, Unit = "powt."}
                                }
                            },
                            new ExerciseTraining(){ Name = "Allahy", Series = new Serie[]
                                {
                                    new Serie(){ Number = 1, SerialNumber = 15, Unit = "powt."},
                                    new Serie(){ Number = 2, SerialNumber = 15, Unit = "powt."},
                                    new Serie(){ Number = 3, SerialNumber = 15, Unit = "powt."},
                                    new Serie(){ Number = 4, SerialNumber = 15, Unit = "powt."}
                                }
                            }
                        }
                    },
                    new TrainingDay(){ Day = "Czwartek", TypeOfTraining = "Cardio", TrainingPlanId = training1.Id,
                        ExerciseTrainings = new ExerciseTraining[]
                        {
                            new ExerciseTraining(){ Name = "Bieżnia", Series = new Serie[]
                                {
                                    new Serie(){ Number = 1, SerialNumber = 55, Unit = "min."}
                                }
                            }
                        }
                    },
                    new TrainingDay(){ Day = "Piątek", TypeOfTraining = "Siłowy", TrainingPlanId = training1.Id,
                        ExerciseTrainings = new ExerciseTraining[]
                        {
                            new ExerciseTraining(){ Name = "Przysiady", Series = new Serie[]
                                {
                                    new Serie(){ Number = 1, SerialNumber = 15, Unit = "powt."},
                                    new Serie(){ Number = 2, SerialNumber = 12, Unit = "powt."},
                                    new Serie(){ Number = 3, SerialNumber = 10, Unit = "powt."},
                                    new Serie(){ Number = 4, SerialNumber = 8, Unit = "powt."}
                                }
                            },
                            new ExerciseTraining(){ Name = "Martwy ciąg", Series = new Serie[]
                                {
                                    new Serie(){ Number = 1, SerialNumber = 12, Unit = "powt."},
                                    new Serie(){ Number = 2, SerialNumber = 10, Unit = "powt."},
                                    new Serie(){ Number = 3, SerialNumber = 10, Unit = "powt."},
                                    new Serie(){ Number = 4, SerialNumber = 8, Unit = "powt."}
                                }
                            },
                            new ExerciseTraining(){ Name = "Wyciskanie na ławce skośnej", Series = new Serie[]
                                {
                                    new Serie(){ Number = 1, SerialNumber = 12, Unit = "powt."},
                                    new Serie(){ Number = 2, SerialNumber = 10, Unit = "powt."},
                                    new Serie(){ Number = 3, SerialNumber = 10, Unit = "powt."},
                                    new Serie(){ Number = 4, SerialNumber = 8, Unit = "powt."}
                                }
                            },
                            new ExerciseTraining(){ Name = "Wyciskanie żołnierskie", Series = new Serie[]
                                {
                                    new Serie(){ Number = 1, SerialNumber = 12, Unit = "powt."},
                                    new Serie(){ Number = 2, SerialNumber = 10, Unit = "powt."},
                                    new Serie(){ Number = 3, SerialNumber = 10, Unit = "powt."}
                                }
                            },
                            new ExerciseTraining(){ Name = "Allahy", Series = new Serie[]
                                {
                                    new Serie(){ Number = 1, SerialNumber = 15, Unit = "powt."},
                                    new Serie(){ Number = 2, SerialNumber = 15, Unit = "powt."},
                                    new Serie(){ Number = 3, SerialNumber = 15, Unit = "powt."},
                                    new Serie(){ Number = 4, SerialNumber = 15, Unit = "powt."}
                                }
                            }
                        }
                    },
                    new TrainingDay(){ Day = "Sobota", TypeOfTraining = "FREE TIME", TrainingPlanId = training1.Id,
                        ExerciseTrainings = new ExerciseTraining[]
                        {
                            new ExerciseTraining(){ Series = new Serie[]
                                {
                                    new Serie(){ }
                                }
                            },                            
                        }
                    },
                    new TrainingDay(){ Day = "Niedziela", TypeOfTraining = "FREE TIME", TrainingPlanId = training1.Id,
                        ExerciseTrainings = new ExerciseTraining[]
                        {
                            new ExerciseTraining(){ Series = new Serie[]
                                {
                                    new Serie(){ }
                                }
                            },
                        }
                    },

                    //new TrainingDay(){ Day = "Poniedziałek", TypeOfTraining = "Siłowy", TrainingPlanId = training2.Id},
                    //new TrainingDay(){ Day = "Wtorek", TypeOfTraining = "Cardio", TrainingPlanId = training2.Id},
                    //new TrainingDay(){ Day = "Środa", TypeOfTraining = "Siłowy", TrainingPlanId = training2.Id},
                    //new TrainingDay(){ Day = "Czwartek", TypeOfTraining = "Cardio", TrainingPlanId = training2.Id},
                    //new TrainingDay(){ Day = "Piątek", TypeOfTraining = "Siłowy", TrainingPlanId = training2.Id},
                    //new TrainingDay(){ Day = "Sobota", TypeOfTraining = "FREE TIME", TrainingPlanId = training2.Id},
                    //new TrainingDay(){ Day = "Niedziela", TypeOfTraining = "FREE TIME", TrainingPlanId = training2.Id},

                    //new TrainingDay(){ Day = "Poniedziałek", TypeOfTraining = "Siłowy", TrainingPlanId = training3.Id},
                    //new TrainingDay(){ Day = "Wtorek", TypeOfTraining = "Cardio", TrainingPlanId = training3.Id},
                    //new TrainingDay(){ Day = "Środa", TypeOfTraining = "Siłowy", TrainingPlanId = training3.Id},
                    //new TrainingDay(){ Day = "Czwartek", TypeOfTraining = "Cardio", TrainingPlanId = training3.Id},
                    //new TrainingDay(){ Day = "Piątek", TypeOfTraining = "Siłowy", TrainingPlanId = training3.Id},
                    //new TrainingDay(){ Day = "Sobota", TypeOfTraining = "FREE TIME", TrainingPlanId = training3.Id},
                    //new TrainingDay(){ Day = "Niedziela", TypeOfTraining = "FREE TIME", TrainingPlanId = training3.Id},

                    //new TrainingDay(){ Day = "Poniedziałek", TypeOfTraining = "Siłowy", TrainingPlanId = training4.Id},
                    //new TrainingDay(){ Day = "Wtorek", TypeOfTraining = "Cardio", TrainingPlanId = training4.Id},
                    //new TrainingDay(){ Day = "Środa", TypeOfTraining = "Siłowy", TrainingPlanId = training4.Id},
                    //new TrainingDay(){ Day = "Czwartek", TypeOfTraining = "Cardio", TrainingPlanId = training4.Id},
                    //new TrainingDay(){ Day = "Piątek", TypeOfTraining = "Siłowy", TrainingPlanId = training4.Id},
                    //new TrainingDay(){ Day = "Sobota", TypeOfTraining = "FREE TIME", TrainingPlanId = training4.Id},
                    //new TrainingDay(){ Day = "Niedziela", TypeOfTraining = "FREE TIME", TrainingPlanId = training4.Id}
                });
                context.SaveChanges();
            } // TrainingDays
        }
    }
}
