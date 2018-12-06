﻿using System;
using System.Collections.Generic;
using System.Linq;
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
    [AllowAnonymous]
    public class TrainingController : BaseController
    {
        private readonly ITrainingService _trainingService;

        public TrainingController(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }

        [HttpPost]
        public async Task<IActionResult> AddTraining(int idUser, int idTrainer, [FromBody]TrainingPlanBindingModel model)
        {

            var result = await _trainingService.InsertTraining(idUser, idTrainer, model);

            if (result.ErrorOccurred)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("{trainingId}")]
        public async Task<IActionResult> DeleteTraining(int trainingId)
        {
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

        [HttpGet("TrainingUsers/{userId}")]
        public IActionResult GetTrainingUsers(int userId)
        {
            var result = _trainingService.GetTrainingUsers(userId);
            if (result.ErrorOccurred)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("Training/{trainingId}")]
        public async Task<IActionResult> EditTraining(int trainingId, EditTrainingPlanBindingModel model)
        {
            var result = await _trainingService.EditTraining(trainingId, model);
            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut("day/{dayId}")]
        public async Task<IActionResult> EditDay(int dayId, EditTrainingDayBindingModel model)
        {
            var result = await _trainingService.EditDay(dayId, model);
            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut("exercise/{exerciseId}")]
        public async Task<IActionResult> EditExercise(int exerciseId, EditExerciseTrainingBindingModel model)
        {
            var result = await _trainingService.EditExercise(exerciseId, model);
            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut("serie/{serieId}")]
        public async Task<IActionResult> EditSerie(int serieId, EditSerieBindingModel model)
        {
            var result = await _trainingService.EditSerie(serieId, model);
            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}