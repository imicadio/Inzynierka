using Engineer.Models;
using Engineer.Models.BindingModel.Training;
using Engineer.Models.Dto.Training;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Engineer.Services.Interface
{
    public interface ITrainingService
    {
        Task<ResponseDto<BaseModelDto>> DeleteTraining(int trainingId);
        Task<ResponseDto<BaseModelDto>> InsertTraining(int idUser, int idTrainer, TrainingPlanBindingModel model);
        Task<ResponseDto<BaseModelDto>> EditTraining(int trainingId, TrainingPlanBindingModel model);
        ResponseDto<TrainingDto> GetTraining(int trainingId);
        ResponseDto<TrainingsDto> GetTrainings();
    }
}
