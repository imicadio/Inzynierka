using Engineer.Models;
using Engineer.Models.BindingModel.Training;
using Engineer.Models.BindingModel.Training.Edit;
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
        ResponseDto<TrainingsDto> GetTrainingUsers(int userId);

        Task<ResponseDto<BaseModelDto>> EditDay(int dayId, EditTrainingDayBindingModel model);
        Task<ResponseDto<BaseModelDto>> EditExercise(int exerciseId, EditExerciseTrainingBindingModel model);
        Task<ResponseDto<BaseModelDto>> EditSerie(int serieId, EditSerieBindingModel model);
    }
}
