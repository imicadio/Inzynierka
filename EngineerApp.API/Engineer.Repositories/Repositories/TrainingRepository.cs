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

        public async Task DeletetAsync(TrainingDay trainingDay)
        {
            _context.TrainingDays.Remove(trainingDay);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(TrainingDay trainingDay)
        {
            _context.TrainingDays.Update(trainingDay);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<TrainingDay> GetAll()
        {
            return _context.TrainingDays
                .Include(x => x.ExerciseTrainings)
                    .ThenInclude(y => y.Series);
        }

        public TrainingDay GetById(int id)
        {
            return _context.TrainingDays
                .Include(x => x.ExerciseTrainings)
                .SingleOrDefault(s => s.Id == id);
        }

        public TrainingDay GetByName(string name)
        {
            return _context.TrainingDays
                .Include(x => x.ExerciseTrainings)
                .SingleOrDefault(s => s.Name == name);
        }

        public async Task<TrainingDay> InsertAsync(TrainingDay trainingDay)
        {
            var result = await _context.TrainingDays.AddAsync(trainingDay);
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
    }
}
