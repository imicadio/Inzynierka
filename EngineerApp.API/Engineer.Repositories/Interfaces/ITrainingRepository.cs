using Engineer.Models.Models.Trainings;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Engineer.Repositories.Interfaces
{
    public interface ITrainingRepository
    {
        IEnumerable<TrainingPlan> GetAll();
        IEnumerable<TrainingPlan> GetAllTrainingUser(int id);

        TrainingPlan GetById(int id);
        TrainingPlan GetByName(string name);
        TrainingDay GetDayById(int id);
        ExerciseTraining GetExerciseById(int id);
        Serie GetSerieById(int id);

        Task<TrainingPlan> InsertAsync(TrainingPlan trainingPlan);
        Task<TrainingDay> InsertTrainingDayAsync(TrainingDay trainingDay);
        Task<ExerciseTraining> InsertExerciseTrainingAsync(ExerciseTraining exerciseTraining);
        Task<Serie> InsertSerieAsync(Serie serie);  

        Task EditAsync(TrainingPlan trainingPlan);
        Task EditAsyncDay(TrainingDay trainingDay);
        Task EditAsyncExercise(ExerciseTraining exerciseTraining);
        Task EditAsyncSerie(Serie serie);

        Task DeletetAsync(TrainingPlan trainingPlan);
        Task DeleteAsyncDay(TrainingDay trainingDay);
    }
}
