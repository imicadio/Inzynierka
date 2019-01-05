﻿using AutoMapper;
using Engineer.Models;
using Engineer.Models.BindingModel;
using Engineer.Models.BindingModel.Training;
using Engineer.Models.BindingModel.Training.Edit;
using Engineer.Models.Dto;
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

        public async Task<ResponseDto<BaseModelDto>> EditDay(int dayId, EditTrainingDayBindingModel model)
        {
            var response = new ResponseDto<BaseModelDto>();

            var day = _trainingRepository.GetDayById(dayId);

            if (day == null)
            {
                response.Errors.Add("Dzień, który chcesz zmodyfikować nie istnieje.");
                return response;
            }

            day.Day = model.Day;
            day.TypeOfTraining = model.TypeOfTraining;

            await _trainingRepository.EditAsyncDay(day);

            return response;
        }

        public async Task<ResponseDto<BaseModelDto>> EditExercise(int exerciseId, EditExerciseTrainingBindingModel model)
        {
            var response = new ResponseDto<BaseModelDto>();

            var exercise = _trainingRepository.GetExerciseById(exerciseId);

            if (exercise == null)
            {
                response.Errors.Add("Cwiczenie, który chcesz zmodyfikować nie istnieje.");
                return response;
            }

            exercise.Name = model.Name;
            exercise.Description = model.Description;

            await _trainingRepository.EditAsyncExercise(exercise);

            return response;
        }

        public async Task<ResponseDto<BaseModelDto>> EditSerie(int serieId, EditSerieBindingModel model)
        {
            var response = new ResponseDto<BaseModelDto>();

            var serie = _trainingRepository.GetSerieById(serieId);

            if (serie == null)
            {
                response.Errors.Add("Seria, który chcesz zmodyfikować nie istnieje.");
                return response;
            }

            serie.SerialNumber = model.SerialNumber;
            serie.Number = model.Number;
            serie.Unit = model.Unit;

            await _trainingRepository.EditAsyncSerie(serie);

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

            // Modyfikacja treningu - PUT
            training.Name = model.Name;            

            await _trainingRepository.EditAsync(training);
            
            // Kaskadowe usuwanie dni treningowych
            // Lista przechowuje Id dni, które zostaną usunięte
            List<int> listId = new List<int>();

            foreach (TrainingDay day in training.TrainingDays)
            {
                var trainingDay = _trainingRepository.GetDayById(day.Id);

                listId.Add(trainingDay.Id);
            }

            // Kaskadowe usuwanie dni treningowych
            for (int i = 0; i < listId.Count(); i++)
            {
                var trainingDay = _trainingRepository.GetDayById(listId[i]);

                if (trainingDay == null)
                {
                    response.Errors.Add("Dzień, który chcesz usunąć nie istnieje");
                    return response;
                }

                await _trainingRepository.DeleteAsyncDay(trainingDay);
            }

            foreach (TrainingDayBindingModel item in model.TrainingDayBindingModels)
            {
                TrainingDay trainingDay = new TrainingDay()
                {
                    Day = item.Day,
                    TypeOfTraining = item.TypeOfTraining,
                    TrainingPlanId = training.Id
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

                    int numberSerial = 1;

                    var insertExercise = await _trainingRepository.InsertExerciseTrainingAsync(exerciseTraining);

                    foreach (SerieBindingModel serie in exercise.SerieBindingModels)
                    {
                        Serie series = new Serie()
                        {
                            ExerciseTrainingId = insertExercise.Id,
                            SerialNumber = numberSerial,
                            Number = serie.Number,
                            Unit = serie.Unit
                        };

                        var insertSerie = await _trainingRepository.InsertSerieAsync(series);

                        numberSerial++;
                    }
                }
            }

            return response;
        }

        public ResponseDto<SearchResult<TrainingForSearchDto>> GetPaginationTrainings(int userId, SearchBindingModel parametes)
        {
            var result = new ResponseDto<SearchResult<TrainingForSearchDto>>();

            var trainings = _trainingRepository.GetByParameters(userId, parametes);

            if (trainings.TotalPageCount == 0)
            {
                result.Errors.Add("Nie znaleziono takich marek piw");
                return result;
            }

            if (parametes.PageNumber > trainings.TotalPageCount)
            {
                result.Errors.Add($"Strona {parametes.PageNumber - 1} wykracza poza limit {trainings.TotalPageCount - 1}");
                return result;
            }

            result.Object = trainings;
            return result;
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

        public ResponseDto<TrainingsDto> GetTrainingUsers(int userId)
        {            
            var response = new ResponseDto<TrainingsDto>
            {
                Object = new TrainingsDto()
            };

            var trainings = _trainingRepository.GetAllTrainingUser(userId).ToList();
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
                DateStart = model.DateStart,
                DateEnd = model.DateEnd,
                UserPlan = userId,
                TrainerPlan = trainerId,
                TrainerName = trainerId.UserName,
                UserName = userId.UserName
            };

            var insertTraining =  await _trainingRepository.InsertAsync(training);

            if (insertTraining == null)
            {
                response.Errors.Add("Wystąpił błąd podczas dodawania treningu");
                return response;
            }

            foreach (TrainingDayBindingModel item in model.TrainingDayBindingModels)
            {
                TrainingDay trainingDay = new TrainingDay()
                {
                    Day = item.Day,
                    TypeOfTraining = item.TypeOfTraining,
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

                    int numberSerial = 1;

                    var insertExercise = await _trainingRepository.InsertExerciseTrainingAsync(exerciseTraining);

                    foreach (SerieBindingModel serie in exercise.SerieBindingModels)
                    {
                        Serie series = new Serie()
                        {
                            ExerciseTrainingId = insertExercise.Id,
                            SerialNumber = numberSerial,
                            Number = serie.Number,
                            Unit = serie.Unit
                        };

                        var insertSerie = await _trainingRepository.InsertSerieAsync(series);

                        numberSerial++;
                    }
                }
            }

            return response;
        }        
    }
}
