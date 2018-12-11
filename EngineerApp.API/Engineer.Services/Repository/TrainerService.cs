
using AutoMapper;
using Engineer.Models;
using Engineer.Models.Dto.User;
using Engineer.Models.Models;
using Engineer.Repositories.Interfaces;
using Engineer.Services.Interface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Engineer.Services.Repository
{
    public class TrainerService : ITrainerService
    {
        private readonly ITrainerRepository _trainerRepository;
        private readonly IMapper _mapper;
        private readonly IDatingRepository _repoUser;
        private readonly UserManager<User> _userManager;

        public TrainerService(ITrainerRepository trainerRepository, IMapper mapper, IDatingRepository repoUser, UserManager<User> userManager)
        {
            _trainerRepository = trainerRepository;
            _mapper = mapper;
            _repoUser = repoUser;
            _userManager = userManager;
        }

        public async Task<ResponseDto<BaseModelDto>> InsertPupil(int id, UserForRegisterDto user)
        {
            var response = new ResponseDto<BaseModelDto>();

            var trainer = _repoUser.GetByUserId(id);

            if (trainer == null)
            {
                response.Errors.Add("Wystąpił błąd, spróbuj ponownie później.");
                return response;
            }

            var userToCreate = _mapper.Map<User>(user);

            var result = await _userManager.CreateAsync(userToCreate, user.Password);

            var userToReturn = _mapper.Map<UserForDetailDto>(userToCreate);

            if (result.Succeeded)
            {
                _userManager.AddToRoleAsync(userToCreate, "User").Wait();

                var pupil = _repoUser.GetByUserId(userToReturn.Id);

                Pupil newPupil = new Pupil()
                {
                    TrainerId = trainer.Id,
                    PupilId = pupil.Id
                };

                var addPupil = await _trainerRepository.InertPupil(newPupil);
            }
            else
            {
                response.Errors.Add("Użytkownik o podanej nazwie już istnieje.");
                return response;
            }

            return response;
        }
    }
}