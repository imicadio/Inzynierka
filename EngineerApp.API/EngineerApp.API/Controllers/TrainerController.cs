using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Engineer.Models.Dto.User;
using Engineer.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EngineerApp.API.Controllers
{
    [Authorize]
    public class TrainerController : BaseController
    {
        private readonly ITrainerService _trainerService;

        public TrainerController(ITrainerService trainerService)
        {
            _trainerService = trainerService;
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> InsertPupil(int id, UserForRegisterDto user)
        {
            if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var result = await _trainerService.InsertPupil(id, user);

            if (result.ErrorOccurred)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
