using Engineer.Models.BindingModel;
using Engineer.Models.Dto;
using Engineer.Models.Dto.Training;
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

        public async Task DeleteAsyncDay(TrainingDay trainingDay)
        {
            _context.TrainingDays.Remove(trainingDay);
            await _context.SaveChangesAsync();
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

        public SearchResult<TrainingForSearchDto> GetByParameters(int userId, SearchBindingModel parametes)
        {
            IEnumerable<TrainingPlan> trainings;

            if((parametes.Query != null && parametes.PresentDay != null && parametes.EndDay != null))
            {
                trainings = _context.TrainingPlans.Where(b => ((b.UserId == userId) || (b.TrainerId == userId)) && ((b.Name.Contains(parametes.Query) || b.UserName.Contains(parametes.Query))) && ((b.DateEnd >= parametes.PresentDay) && (b.DateEnd <= parametes.EndDay))).ToList();
            }
            else if (parametes.Query != null)
            {
                trainings = _context.TrainingPlans.Where(b => ((b.UserId == userId) || (b.TrainerId == userId)) && ((b.Name.Contains(parametes.Query) || b.UserName.Contains(parametes.Query)))).ToList();
            }
            else
            {
                trainings = _context.TrainingPlans.Where(u => u.UserId == userId || u.TrainerId == userId).ToList();
            }

            var totalPages = (int)Math.Ceiling((decimal)trainings.Count() / parametes.Limit);

            var countList = (int)Math.Ceiling((decimal)trainings.Count());

            var property = typeof(TrainingPlan).GetProperty(parametes.Sort.FirstCharToUpper());

            if(property == null)
            {
                var defaultParameters = new SearchBindingModel();
                property = typeof(TrainingPlan).GetProperty(defaultParameters.Sort);
            }           

            trainings = parametes.Ascending
                ? trainings.OrderByDescending(b => property.GetValue(b))
                : trainings.OrderBy(b => property.GetValue(b));

            

            trainings = trainings.Skip(parametes.Limit * (parametes.PageNumber - 1)).Take(parametes.Limit);

            var result = new SearchResult<TrainingForSearchDto>();
            var trainingsForSearch = new List<TrainingForSearchDto>();
            trainings.ToList().ForEach(b =>
                trainingsForSearch.Add(new TrainingForSearchDto
                {
                    Id = b.Id,
                    DateStart = b.DateStart,
                    DateEnd = b.DateEnd,
                    Name = b.Name,
                    TrainerName = b.TrainerName,
                    UserName = b.UserName
                }
            ));          

            result.Count = countList;
            result.CurrentPage = parametes.PageNumber;
            result.TotalPageCount = totalPages;
            result.Results = trainingsForSearch;

            return result;
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

        public async Task<TrainingPlan> InsertAsync(TrainingPlan trainingPlan)
        {
            var result = await _context.TrainingPlans.AddAsync(trainingPlan);
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
