using AutoMapper;
using Engineer.Models;
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

        public Task<ResponseDto<BaseModelDto>> EditTraining(int trainingId, EditTrainingBindingModel model)
        {
            throw new NotImplementedException();
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

        public async Task<ResponseDto<BaseModelDto>> InsertTraining(int idUser, int idTrainer, AddTrainingBindingModel model)
        {
            var response = new ResponseDto<BaseModelDto>();

            var training = _trainingRepository.GetByName(model.Name);

            var userId = _repoUser.GetByUserId(idUser);

            var trainerId = _repoUser.GetByUserId(idTrainer);

            training = new TrainingDay()
            {
                Name = model.Name,
                UserPlan = userId,
                TrainerPlan = trainerId,
                ExerciseTrainings = new List<ExerciseTraining>()
            };

            await _trainingRepository.InsertAsync(training);

            return response;
        }
    }
}
