using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Engineer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EngineerApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : Controller
    {
        protected ResponseDto<BaseModelDto> ModelStateErrors()
        {
            var response = new ResponseDto<BaseModelDto>();

            foreach (var key in ModelState.Keys)
            {
                var value = ViewData.ModelState[key];

                foreach (var error in value.Errors)
                {
                    response.Errors.Add(error.Exception != null ? "Nieprawidłowy format danych" : error.ErrorMessage);
                }
            }
            return response;
        }
    }
}
