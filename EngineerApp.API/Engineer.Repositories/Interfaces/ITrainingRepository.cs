using Engineer.Models.Models.Trainings;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Engineer.Repositories.Interfaces
{
    public interface ITrainingRepository
    {
        TrainingDay GetById(int id);
        TrainingDay GetByName(string name);
        IEnumerable<TrainingDay> GetAll();
        Task InsertAsync(TrainingDay trainingDay);
        Task EditAsync(TrainingDay trainingDay);
        Task DeletetAsync(TrainingDay trainingDay);
    }
}
