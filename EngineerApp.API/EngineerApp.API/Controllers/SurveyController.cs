using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Engineer.Models.BindingModel;
using Engineer.Models.BindingModel.Survey;
using Engineer.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EngineerApp.API.Controllers
{
    [Authorize]
    public class SurveyController : BaseController
    {
        private readonly ISurveyService _surveyService;

        public SurveyController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        [HttpGet("Biceps")]
        public IActionResult GetPaginationBiceps(int userId, [FromQuery] SearchSurveyBindingModels parameters)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelStateErrors());
            }

            parameters.PageNumber = parameters.PageNumber + 1;

            var result = _surveyService.GetPaginationBiceps(userId, parameters);

            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }
            result.Object.CurrentPage = result.Object.CurrentPage - 1;
            result.Object.TotalPageCount = result.Object.TotalPageCount - 1;
            return Ok(result);
        }
        
        [HttpGet("Biceps/{id}")]
        public IActionResult GetBiceps(int id)
        {
            var result = _surveyService.GetBiceps(id);
            if (result.ErrorOccurred)
                return BadRequest(result);

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("CurrentSurveys")]
        public IActionResult GetCurrentSurveys(int userId)
        {
            var result = _surveyService.GetCurrentSurveys(userId);
            if (result.ErrorOccurred)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("BodyFat")]
        public IActionResult GetPaginationBodyFat(int userId, [FromQuery] SearchSurveyBindingModels parameters)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelStateErrors());
            }

            parameters.PageNumber = parameters.PageNumber + 1;

            var result = _surveyService.GetPaginationBodyFat(userId, parameters);

            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }
            result.Object.CurrentPage = result.Object.CurrentPage - 1;
            result.Object.TotalPageCount = result.Object.TotalPageCount - 1;
            return Ok(result);
        }

        [HttpGet("BodyFat/{id}")]
        public IActionResult GetBodyFat(int id)
        {
            var result = _surveyService.GetBodyFat(id);
            if (result.ErrorOccurred)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("BodyWeight")]
        public IActionResult GetPaginationBodyWeight(int userId, [FromQuery] SearchSurveyBindingModels parameters)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelStateErrors());
            }

            parameters.PageNumber = parameters.PageNumber + 1;

            var result = _surveyService.GetPaginationBodyWeight(userId, parameters);

            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }
            result.Object.CurrentPage = result.Object.CurrentPage - 1;
            result.Object.TotalPageCount = result.Object.TotalPageCount - 1;
            return Ok(result);
        }

        [HttpGet("BodyWeight/{id}")]
        public IActionResult GetBodyWeight(int id)
        {
            var result = _surveyService.GetBodyWeight(id);
            if (result.ErrorOccurred)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("Calf")]
        public IActionResult GetPaginationBodyCalf(int userId, [FromQuery] SearchSurveyBindingModels parameters)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelStateErrors());
            }

            parameters.PageNumber = parameters.PageNumber + 1;

            var result = _surveyService.GetPaginationCalf(userId, parameters);

            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }
            result.Object.CurrentPage = result.Object.CurrentPage - 1;
            result.Object.TotalPageCount = result.Object.TotalPageCount - 1;
            return Ok(result);
        }

        [HttpGet("Calf/{id}")]
        public IActionResult GetCalf(int id)
        {
            var result = _surveyService.GetCalf(id);
            if (result.ErrorOccurred)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("Chest")]
        public IActionResult GetPaginationChest(int userId, [FromQuery] SearchSurveyBindingModels parameters)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelStateErrors());
            }

            parameters.PageNumber = parameters.PageNumber + 1;

            var result = _surveyService.GetPaginationChest(userId, parameters);

            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }
            result.Object.CurrentPage = result.Object.CurrentPage - 1;
            result.Object.TotalPageCount = result.Object.TotalPageCount - 1;
            return Ok(result);
        }

        [HttpGet("Chest/{id}")]
        public IActionResult GetChest(int id)
        {
            var result = _surveyService.GetChest(id);
            if (result.ErrorOccurred)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("Hip")]
        public IActionResult GetPaginationHip(int userId, [FromQuery] SearchSurveyBindingModels parameters)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelStateErrors());
            }

            parameters.PageNumber = parameters.PageNumber + 1;

            var result = _surveyService.GetPaginationHip(userId, parameters);

            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }
            result.Object.CurrentPage = result.Object.CurrentPage - 1;
            result.Object.TotalPageCount = result.Object.TotalPageCount - 1;
            return Ok(result);
        }

        [HttpGet("Hip/{id}")]
        public IActionResult GetHip(int id)
        {
            var result = _surveyService.GetHip(id);
            if (result.ErrorOccurred)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("Thigh")]
        public IActionResult GetPaginationThigh(int userId, [FromQuery] SearchSurveyBindingModels parameters)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelStateErrors());
            }

            parameters.PageNumber = parameters.PageNumber + 1;

            var result = _surveyService.GetPaginationThigh(userId, parameters);

            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }
            result.Object.CurrentPage = result.Object.CurrentPage - 1;
            result.Object.TotalPageCount = result.Object.TotalPageCount - 1;
            return Ok(result);
        }

        [HttpGet("Thigh/{id}")]
        public IActionResult GetThigh(int id)
        {
            var result = _surveyService.GetThigh(id);
            if (result.ErrorOccurred)
                return BadRequest(result);

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("Add/Biceps")]
        public async Task<IActionResult> AddBiceps(int idUser, [FromQuery]SurveyBindingModel model)
        {
            //if (idUser != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            //    return Unauthorized();

            var result = await _surveyService.InsertBiceps(idUser, model);

            if (result.ErrorOccurred)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("Add/BodyFat")]
        public async Task<IActionResult> AddBodyFat(int idUser, [FromQuery]SurveyBindingModel model)
        {
            if (idUser != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var result = await _surveyService.InsertBodyFat(idUser, model);

            if (result.ErrorOccurred)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("Add/BodyWeight")]
        public async Task<IActionResult> AddBodyWeight(int idUser, [FromQuery]SurveyBindingModel model)
        {
            if (idUser != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var result = await _surveyService.InsertBodyWeight(idUser, model);

            if (result.ErrorOccurred)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("Add/Calf")]
        public async Task<IActionResult> AddCalf(int idUser, [FromQuery]SurveyBindingModel model)
        {
            if (idUser != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var result = await _surveyService.InsertCalf(idUser, model);

            if (result.ErrorOccurred)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("Add/Chest")]
        public async Task<IActionResult> AddChest(int idUser, [FromQuery]SurveyBindingModel model)
        {
            if (idUser != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var result = await _surveyService.InsertChest(idUser, model);

            if (result.ErrorOccurred)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("Add/Hip")]
        public async Task<IActionResult> AddHip(int idUser, [FromQuery]SurveyBindingModel model)
        {
            if (idUser != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var result = await _surveyService.InsertHip(idUser, model);

            if (result.ErrorOccurred)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("Add/Thigh")]
        public async Task<IActionResult> AddThigh(int idUser, [FromQuery]SurveyBindingModel model)
        {
            if (idUser != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var result = await _surveyService.InsertThigh(idUser, model);

            if (result.ErrorOccurred)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("Edit/Biceps")]
        public async Task<IActionResult> EditBiceps(int userId, int id, [FromBody] SurveyEditBindingModel model)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var result = await _surveyService.EditBiceps(id, model);
            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut("Edit/BodyFat")]
        public async Task<IActionResult> EditBodyFats(int userId, int id, [FromBody] SurveyEditBindingModel model)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var result = await _surveyService.EditBodyFat(id, model);
            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut("Edit/BodyWeight")]
        public async Task<IActionResult> EditBodyWeight(int userId, int id, [FromBody] SurveyEditBindingModel model)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var result = await _surveyService.EditBodyWeight(id, model);
            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut("Edit/Calf")]
        public async Task<IActionResult> EditCalf(int userId, int id, [FromBody] SurveyEditBindingModel model)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var result = await _surveyService.EditCalf(id, model);
            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut("Edit/Chest")]
        public async Task<IActionResult> EditChest(int userId, int id, [FromBody] SurveyEditBindingModel model)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var result = await _surveyService.EditChest(id, model);
            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut("Edit/Hip")]
        public async Task<IActionResult> EditHip(int userId, int id, [FromBody] SurveyEditBindingModel model)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var result = await _surveyService.EditHip(id, model);
            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut("Edit/Thigh")]
        public async Task<IActionResult> EditThigh(int userId, int id, [FromBody] SurveyEditBindingModel model)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var result = await _surveyService.EditThigh(id, model);
            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpDelete("Delete/Biceps")]
        public async Task<IActionResult> DeleteBiceps(int id, int userId)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var result = await _surveyService.DeleteBiceps(id);

            if (result.ErrorOccurred)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("Delete/BodyFat")]
        public async Task<IActionResult> DeleteBodyFat(int id, int userId)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var result = await _surveyService.DeleteBodyFat(id);

            if (result.ErrorOccurred)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("Delete/BodyWeight")]
        public async Task<IActionResult> DeleteBodyWeight(int id, int userId)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var result = await _surveyService.DeleteBodyWeight(id);

            if (result.ErrorOccurred)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("Delete/Calf")]
        public async Task<IActionResult> DeleteCalf(int id, int userId)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var result = await _surveyService.DeleteCalf(id);

            if (result.ErrorOccurred)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("Delete/Chest")]
        public async Task<IActionResult> DeleteChest(int id, int userId)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var result = await _surveyService.DeleteChest(id);

            if (result.ErrorOccurred)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("Delete/Hip")]
        public async Task<IActionResult> DeleteHip(int id, int userId)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var result = await _surveyService.DeleteHip(id);

            if (result.ErrorOccurred)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("Delete/Thigh")]
        public async Task<IActionResult> DeleteThigh(int id, int userId)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var result = await _surveyService.DeleteThigh(id);

            if (result.ErrorOccurred)
                return BadRequest(result);

            return Ok(result);
        }
    }
}