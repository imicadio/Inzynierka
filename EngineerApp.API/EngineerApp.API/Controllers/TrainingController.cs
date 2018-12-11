using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Engineer.Models.BindingModel.Training;
using Engineer.Models.BindingModel.Training.Edit;
using Engineer.Models.Dto.Training;
using Engineer.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EngineerApp.API.Controllers
{
    [Authorize]
    public class TrainingController : BaseController
    {
        private readonly ITrainingService _trainingService;

        public TrainingController(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }

        [Authorize(Policy = "RequireTrainerRole")]
        [HttpPost]
        public async Task<IActionResult> AddTraining(int idUser, int idTrainer, [FromBody]TrainingPlanBindingModel model)
        {
            if (idTrainer != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var result = await _trainingService.InsertTraining(idUser, idTrainer, model);

            if (result.ErrorOccurred)
                return BadRequest(result);

            return Ok(result);
        }

        [Authorize(Policy = "RequireTrainerRole")]
        [HttpDelete]
        public async Task<IActionResult> DeleteTraining(int trainingId, int trainerId)
        {
            if (trainerId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var result = await _trainingService.DeleteTraining(trainingId);

            if (result.ErrorOccurred)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAllTrainings()
        {
            var result = _trainingService.GetTrainings();
            if (result.ErrorOccurred)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("{trainingId}")]
        public IActionResult GetTraining(int trainingId)
        {
            var result = _trainingService.GetTraining(trainingId);
            if (result.ErrorOccurred)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("Users/{userId}")]
        public IActionResult GetTrainingUsers(int userId)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var result = _trainingService.GetTrainingUsers(userId);
            if (result.ErrorOccurred)
                return BadRequest(result);

            return Ok(result);
        }

        [Authorize(Policy = "RequireTrainerRole")]
        [HttpPut]
        public async Task<IActionResult> EditTraining(int trainingId, int trainerId, TrainingPlanBindingModel model)
        {
            if (trainerId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var result = await _trainingService.EditTraining(trainingId, model);
            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        //[Authorize(Policy = "RequireTrainerRole")]
        //[HttpPut("day")]
        //public async Task<IActionResult> EditDay(int dayId, int trainerId, EditTrainingDayBindingModel model)
        //{
        //    if (trainerId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
        //        return Unauthorized();

        //    var result = await _trainingService.EditDay(dayId, model);
        //    if (result.ErrorOccurred)
        //    {
        //        return BadRequest(result);
        //    }

        //    return Ok(result);
        //}

        //[Authorize(Policy = "RequireTrainerRole")]
        //[HttpPut("exercise")]
        //public async Task<IActionResult> EditExercise(int exerciseId, int trainerId, EditExerciseTrainingBindingModel model)
        //{
        //    if (trainerId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
        //        return Unauthorized();

        //    var result = await _trainingService.EditExercise(exerciseId, model);
        //    if (result.ErrorOccurred)
        //    {
        //        return BadRequest(result);
        //    }

        //    return Ok(result);
        //}

        //[Authorize(Policy = "RequireTrainerRole")]
        //[HttpPut("serie")]
        //public async Task<IActionResult> EditSerie(int serieId, int trainerId, EditSerieBindingModel model)
        //{
        //    if (trainerId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
        //        return Unauthorized();

        //    var result = await _trainingService.EditSerie(serieId, model);
        //    if (result.ErrorOccurred)
        //    {
        //        return BadRequest(result);
        //    }

        //    return Ok(result);
        //}
    }
}