using Engineer.Models;
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
        Task<ResponseDto<BaseModelDto>> InsertTraining(int idUser, int idTrainer, AddTrainingBindingModel model);
        Task<ResponseDto<BaseModelDto>> EditTraining(int trainingId, EditTrainingBindingModel model);
        ResponseDto<TrainingDto> GetTraining(int trainingId);
        ResponseDto<TrainingsDto> GetTrainings();
    }
}
