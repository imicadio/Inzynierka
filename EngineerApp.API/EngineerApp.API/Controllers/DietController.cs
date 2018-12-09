﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Engineer.Models.BindingModel.Diet;
using Engineer.Models.BindingModel.Diet.Edit;
using Engineer.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EngineerApp.API.Controllers
{
    [AllowAnonymous]
    public class DietController : BaseController
    {
        private readonly IDietService _dietService;

        public DietController(IDietService dietService)
        {
            _dietService = dietService;
        }

        [HttpGet]
        public IActionResult GetAllDiets()
        {
            var result = _dietService.GetAllDiets();

            if (result.ErrorOccurred)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetDiet(int id)
        {
            var result = _dietService.GetDiet(id);
            if (result.ErrorOccurred)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("Users/{id}")]
        public IActionResult GetDietUsers(int userId)
        {
            var result = _dietService.GetAllDietsUser(userId);

            if (result.ErrorOccurred)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddDiet(int idUser, int idTrainer, [FromBody]DietPlanBindingModel model)
        {
            var result = await _dietService.InsertDiet(idUser, idTrainer, model);

            if (result.ErrorOccurred)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiet(int id)
        {
            var result = await _dietService.DeleteDiet(id);

            if (result.ErrorOccurred)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut]
        public async Task <IActionResult> EditDiet(int dietId, int trainerId, DietPlanBindingModel model)
        {
            var result = await _dietService.EditDiet(dietId, model);

            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        //[HttpPut("day")]
        //public async Task<IActionResult> EditDay(int dayId, EditDietDayBindingModel model)
        //{
        //    var result = await _dietService.EditDay(dayId, model);

        //    if (result.ErrorOccurred)
        //    {
        //        return BadRequest(result);
        //    }

        //    return Ok(result);
        //}

        //[HttpPut("detail")]
        //public async Task<IActionResult> EditDetail(int detailId, EditDietDetailBindingModel model)
        //{
        //    var result = await _dietService.EditDetail(detailId, model);

        //    if (result.ErrorOccurred)
        //    {
        //        return BadRequest(result);
        //    }

        //    return Ok(result);
        //}

        //[HttpPut("prodyct")]
        //public async Task<IActionResult> EditProduct(int id, EditDietProductBindingModel model)
        //{
        //    var result = await _dietService.EditProduct(id, model);

        //    if (result.ErrorOccurred)
        //    {
        //        return BadRequest(result);
        //    }

        //    return Ok(result);
        //}
    }
}
