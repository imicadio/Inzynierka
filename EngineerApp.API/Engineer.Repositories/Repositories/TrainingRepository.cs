using Engineer.Models.Models.Trainings;
using Engineer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engineer.Repositories.Repositories
{
    public class TrainingRepository : ITrainingRepository
    {
        private readonly DataContext _context;

        public TrainingRepository(DataContext context)
        {
            _context = context;
        }

        public async Task DeletetAsync(TrainingPlan trainingPlan)
        {
            _context.TrainingPlans.Remove(trainingPlan);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(TrainingPlan trainingPlan)
        {
            _context.TrainingPlans.Update(trainingPlan);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsyncDay(TrainingDay trainingDay)
        {
            _context.TrainingDays.Update(trainingDay);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsyncExercise(ExerciseTraining exerciseTraining)
        {
            _context.ExerciseTrainings.Update(exerciseTraining);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsyncSerie(Serie serie)
        {
            _context.Series.Update(serie);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<TrainingPlan> GetAll()
        {
            return _context.TrainingPlans
                .Include(x => x.TrainingDays)
                    .ThenInclude(y => y.ExerciseTrainings)
                        .ThenInclude(z => z.Series);
        }

        public IEnumerable<TrainingPlan> GetAllTrainingUser(int id)
        {
            return _context.TrainingPlans
                .Include(x => x.TrainingDays)
                    .ThenInclude(y => y.ExerciseTrainings)
                        .ThenInclude(z => z.Series)
                .Where(x => x.TrainerId == id || x.UserId == id)
                .OrderByDescending(x => x.Id);
        }

        public TrainingPlan GetById(int id)
        {
            return _context.TrainingPlans
                .Include(x => x.TrainingDays)
                    .ThenInclude(y => y.ExerciseTrainings)
                            .ThenInclude(z => z.Series)
                .SingleOrDefault(s => s.Id == id);
        }

        public TrainingPlan GetByName(string name)
        {
            return _context.TrainingPlans
                .Include(x => x.TrainingDays)
                    .ThenInclude(y => y.ExerciseTrainings)
                        .ThenInclude(z => z.Series)
                .SingleOrDefault(s => s.Name == name);
        }

        public TrainingDay GetDayById(int id)
        {
            return _context.TrainingDays.SingleOrDefault(x => x.Id == id);
        }

        public ExerciseTraining GetExerciseById(int id)
        {
            return _context.ExerciseTrainings.SingleOrDefault(x => x.Id == id);
        }

        public Serie GetSerieById(int id)
        {
            return _context.Series.SingleOrDefault(x => x.Id == id);
        }

        public async Task<TrainingPlan> InsertAsync(TrainingPlan trainingDay)
        {
            var result = await _context.TrainingPlans.AddAsync(trainingDay);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<ExerciseTraining> InsertExerciseTrainingAsync(ExerciseTraining exerciseTraining)
        {
            var result = await _context.ExerciseTrainings.AddAsync(exerciseTraining);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Serie> InsertSerieAsync(Serie serie)
        {
            var result = await _context.Series.AddAsync(serie);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TrainingDay> InsertTrainingDayAsync(TrainingDay trainingDay)
        {
            var result = await _context.TrainingDays.AddAsync(trainingDay);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}
