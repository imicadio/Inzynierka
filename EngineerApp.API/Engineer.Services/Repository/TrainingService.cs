using AutoMapper;
using Engineer.Models;
using Engineer.Models.BindingModel.Training;
using Engineer.Models.Dto.Training;
using Engineer.Models.Models.Trainings;
using Engineer.Repositories.Interfaces;
using Engineer.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engineer.Services.Repository
{
    public class TrainingService : ITrainingService
    {
        private readonly ITrainingRepository _trainingRepository;
        private readonly IMapper _mapper;
        private readonly IDatingRepository _repoUser;

        public TrainingService(ITrainingRepository trainingRepository, IMapper mapper, IDatingRepository repoUser)
        {
            _trainingRepository = trainingRepository;
            _mapper = mapper;
            _repoUser = repoUser;
        }

        public async Task<ResponseDto<BaseModelDto>> DeleteTraining(int trainingId)
        {
            var response = new ResponseDto<BaseModelDto>();

            var training = _trainingRepository.GetById(trainingId);

            if(training == null)
            {
                response.Errors.Add("Trening, który chcesz usunąć nie istnieje");
                return response;
            }

            await _trainingRepository.DeletetAsync(training);

            return response;
        }

        public async Task<ResponseDto<BaseModelDto>> EditTraining(int trainingId, TrainingPlanBindingModel model)
        {
            var response = new ResponseDto<BaseModelDto>();

            var training = _trainingRepository.GetById(trainingId);

            if (training == null)
            {
                response.Errors.Add("Trening, który chcesz zmodyfikować nie istnieje.");
                return response;
            }

            training.Name = model.Name;            

            foreach (TrainingDayBindingModel item in model.TrainingDayBindingModels)
            {
                if (training.TrainingDays.FirstOrDefault().Day != item.Day)
                    training.TrainingDays.FirstOrDefault().Day = item.Day;
                            
                foreach (ExerciseTrainingBindingModel exercise in item.ExerciseTrainingBindingModels)
                {
                    if (training.TrainingDays.FirstOrDefault().ExerciseTrainings.FirstOrDefault().Description != exercise.Description)
                        training.TrainingDays.FirstOrDefault().ExerciseTrainings.FirstOrDefault().Description = exercise.Description;

                    foreach (SerieBindingModel serie in exercise.SerieBindingModels)
                    {
                        if (training.TrainingDays.FirstOrDefault().ExerciseTrainings.FirstOrDefault().Series.FirstOrDefault().SerialNumber != serie.SerialNumber)
                            training.TrainingDays.FirstOrDefault().ExerciseTrainings.FirstOrDefault().Series.FirstOrDefault().SerialNumber = serie.SerialNumber;

                        if (training.TrainingDays.FirstOrDefault().ExerciseTrainings.FirstOrDefault().Series.FirstOrDefault().Number != serie.Number)
                            training.TrainingDays.FirstOrDefault().ExerciseTrainings.FirstOrDefault().Series.FirstOrDefault().Number = serie.Number;

                        if (training.TrainingDays.FirstOrDefault().ExerciseTrainings.FirstOrDefault().Series.FirstOrDefault().Unit != serie.Unit)
                            training.TrainingDays.FirstOrDefault().ExerciseTrainings.FirstOrDefault().Series.FirstOrDefault().Unit = serie.Unit;
                    }
                }
            }

            await _trainingRepository.EditAsync(training);

            return response;
        }

        public ResponseDto<TrainingDto> GetTraining(int trainingId)
        {
            var response = new ResponseDto<TrainingDto>
            {
                Object = new TrainingDto()
            };

            var training = _trainingRepository.GetById(trainingId);

            if(training == null)
            {
                response.Errors.Add("Podany trening nie istnieje, utworz nowy trening");
                return response;
            }

            response.Object = _mapper.Map<TrainingDto>(training);

            return response;
        }

        public ResponseDto<TrainingsDto> GetTrainings()
        {
            var response = new ResponseDto<TrainingsDto>
            {
                Object = new TrainingsDto()
            };

            var trainings = _trainingRepository.GetAll().ToList();
            response.Object.Trainings = _mapper.Map<List<TrainingDto>>(trainings);

            return response;
        }

        public async Task<ResponseDto<BaseModelDto>> InsertTraining(int idUser, int idTrainer, TrainingPlanBindingModel model)
        {
            var response = new ResponseDto<BaseModelDto>();

            var userId = _repoUser.GetByUserId(idUser);

            if (userId == null)
            {
                response.Errors.Add("Użytkownik, którego chcesz dodać nie istnieje");
                return response;
            }

            var trainerId = _repoUser.GetByUserId(idTrainer);

            if (trainerId == null)
            {
                response.Errors.Add("Wystąpil błąd, spróbuj ponownie później");
                return response;
            }

            var verifyUser = _repoUser.VerifyPupilTrainer(trainerId.Id, userId.Id);

            if (verifyUser == null)
            {
                response.Errors.Add("Trener nie posiada uprawień dla tego podopiecznego");
                return response;
            }

            TrainingPlan training = new TrainingPlan()
            {
                Name = model.Name,
                UserPlan = userId,
                TrainerPlan = trainerId
            };

            var insertTraining =  await _trainingRepository.InsertAsync(training);

            if (insertTraining == null)
            {
                response.Errors.Add("Wystąpił błąd podczas dodawania projektu");
                return response;
            }

            foreach (TrainingDayBindingModel item in model.TrainingDayBindingModels)
            {
                TrainingDay trainingDay = new TrainingDay()
                {
                    Day = item.Day,
                    TrainingPlanId = insertTraining.Id
                };

                var insertDay = await _trainingRepository.InsertTrainingDayAsync(trainingDay);

                foreach (ExerciseTrainingBindingModel exercise in item.ExerciseTrainingBindingModels)
                {
                    ExerciseTraining exerciseTraining = new ExerciseTraining()
                    {
                        TrainingDayId = insertDay.Id,
                        Name = exercise.Name,
                        Description = exercise.Description
                    };

                    var insertExercise = await _trainingRepository.InsertExerciseTrainingAsync(exerciseTraining);

                    foreach (SerieBindingModel serie in exercise.SerieBindingModels)
                    {
                        Serie series = new Serie()
                        {
                            ExerciseTrainingId = insertExercise.Id,
                            SerialNumber = serie.SerialNumber,
                            Number = serie.Number,
                            Unit = serie.Unit
                        };

                        var insertSerie = await _trainingRepository.InsertSerieAsync(series);
                    }
                }
            }

            return response;
        }
    }
}
