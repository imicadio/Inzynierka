using Engineer.Models;
using Engineer.Models.BindingModel.Diet;
using Engineer.Models.BindingModel.Diet.Edit;
using Engineer.Models.Dto.Diet;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Engineer.Services.Interface
{
    public interface IDietService
    {
        ResponseDto<DietPlanDto> GetDiet(int id);
        ResponseDto<DietsDto> GetAllDiets();
        ResponseDto<DietsDto> GetAllDietsUser(int userId);

        Task<ResponseDto<BaseModelDto>> InsertDiet(int idUser, int idTrainer, DietPlanBindingModel model);
                
        Task<ResponseDto<BaseModelDto>> EditDiet(int id, DietPlanBindingModel model);
        Task<ResponseDto<BaseModelDto>> EditDay(int id, EditDietDayBindingModel model);
        Task<ResponseDto<BaseModelDto>> EditDetail(int id, EditDietDetailBindingModel model);
        Task<ResponseDto<BaseModelDto>> EditProduct(int id, EditDietProductBindingModel model);

        Task<ResponseDto<BaseModelDto>> DeleteDiet(int id);
    }
}
