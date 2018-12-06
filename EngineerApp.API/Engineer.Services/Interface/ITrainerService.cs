using Engineer.Models;
using Engineer.Models.Dto.User;
using Engineer.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Engineer.Services.Interface
{
    public interface ITrainerService
    {
        Task<ResponseDto<BaseModelDto>> InsertPupil(int id, UserForRegisterDto user);
    }
}
