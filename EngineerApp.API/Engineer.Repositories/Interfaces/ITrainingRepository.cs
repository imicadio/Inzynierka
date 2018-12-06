using Engineer.Models.Models.Trainings;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Engineer.Repositories.Interfaces
{
    public interface ITrainingRepository
    {
        TrainingPlan GetById(int id);
        TrainingPlan GetByName(string name);
        IEnumerable<TrainingPlan> GetAll();
        Task<TrainingPlan> InsertAsync(TrainingPlan trainingPlan);
        Task EditAsync(TrainingPlan trainingPlan);
        Task DeletetAsync(TrainingPlan trainingPlan);

        TrainingDay GetDayById(int id);
        ExerciseTraining GetExerciseById(int id);
        Serie GetSerieById(int id);

        Task EditAsyncDay(TrainingDay trainingDay);
        Task EditAsyncExercise(ExerciseTraining exerciseTraining);
        Task EditAsyncSerie(Serie serie);

        Task<TrainingDay> InsertTrainingDayAsync(TrainingDay trainingDay);
        Task<ExerciseTraining> InsertExerciseTrainingAsync(ExerciseTraining exerciseTraining);
        Task<Serie> InsertSerieAsync(Serie serie);

        IEnumerable<TrainingPlan> GetAllTrainingUser(int id);
    }
}
