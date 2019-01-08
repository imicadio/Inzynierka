using Engineer.Models.BindingModel;
using Engineer.Models.Dto;
using Engineer.Models.Dto.Diet;
using Engineer.Models.Models.Diets;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Engineer.Repositories.Interfaces
{
    public interface IDietRepository
    {
        SearchResult<DietForSearchDto> GetByParameters(int userId, SearchBindingModel parametes);

        IEnumerable<DietPlan> GetAllDiets();
        IEnumerable<DietPlan> GetAllUserDiets(int id);

        DietPlan GetDietById(int id);
        DietDay GetDayById(int id);
        DietDetail GetDetailById(int id);
        DietProduct GetProductById(int id);

        Task<DietPlan> InsertAsync(DietPlan dietPlan);
        Task<DietDay> InserAsyncDay(DietDay dietDay);
        Task<DietDetail> InsertAsyncDetail(DietDetail dietDetail);
        Task<DietProduct> InsertAsyncProduct(DietProduct dietProduct);

        Task EditAsyncDiet(DietPlan dietPlan);
        Task EditAsyncDay(DietDay dietDay);
        Task EditAsyncDetail(DietDetail dietDetail);
        Task EditAsyncProduct(DietProduct dietProduct);

        Task DeleteAsyncDiet(DietPlan dietPlan);
        Task DeleteAsyncDay(DietDay dietDay);
    }
}
