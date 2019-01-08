using AutoMapper;
using Engineer.Models;
using Engineer.Models.BindingModel;
using Engineer.Models.BindingModel.Diet;
using Engineer.Models.BindingModel.Diet.Edit;
using Engineer.Models.Dto;
using Engineer.Models.Dto.Diet;
using Engineer.Models.Models.Diets;
using Engineer.Repositories.Interfaces;
using Engineer.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engineer.Services.Repository
{
    public class DietService : IDietService
    {
        private readonly IDietRepository _dietRepository;
        private readonly IDatingRepository _repoUser;
        private readonly IMapper _mapper;

        public DietService(IDietRepository dietRepository, IDatingRepository repoUser, IMapper mapper)
        {
            _dietRepository = dietRepository;
            _repoUser = repoUser;
            _mapper = mapper;
        }

        public async Task<ResponseDto<BaseModelDto>> DeleteDiet(int id)
        {
            var response = new ResponseDto<BaseModelDto>();

            var diet = _dietRepository.GetDietById(id);

            if (diet == null)
            {
                response.Errors.Add("Dieta, którą chcesz usunąć nie istnieje");
                return response;
            }

            await _dietRepository.DeleteAsyncDiet(diet);

            return response;
        }

        public async Task<ResponseDto<BaseModelDto>> EditDay(int id, EditDietDayBindingModel model)
        {
            var response = new ResponseDto<BaseModelDto>();

            var day = _dietRepository.GetDayById(id);

            if (day == null)
            {
                response.Errors.Add("Dzień, który chcesz zmodyfikować nie istnieje.");
                return response;
            }

            day.Name = model.Name;

            await _dietRepository.EditAsyncDay(day);

            return response;
        }

        public async Task<ResponseDto<BaseModelDto>> EditDetail(int id, EditDietDetailBindingModel model)
        {
            var response = new ResponseDto<BaseModelDto>();

            var detail = _dietRepository.GetDetailById(id);

            if(detail == null)
            {
                response.Errors.Add("Szczegóły, które chcesz edytować nie istnieją");
                return response;
            }

            detail.Dish = model.Dish;
            detail.Hour = model.Hour;
            detail.Meal = model.Meal;
            detail.Recipe = model.Recipe;

            await _dietRepository.EditAsyncDetail(detail);

            return response;
        }

        public async Task<ResponseDto<BaseModelDto>> EditDiet(int id, DietPlanBindingModel model)
        {
            var response = new ResponseDto<BaseModelDto>();

            var diet = _dietRepository.GetDietById(id);

            if(diet == null)
            {
                response.Errors.Add("Dieta, którą chcesz usunąć nie istnieje");
                return response;
            }

            // Modyfikacja nazwy diety - PUT
            diet.Name = model.Name;

            await _dietRepository.EditAsyncDiet(diet);

            // Kaskadowe usuwanie dni dietetycznych
            // Lista przechowuje Id dni, które zostaną usunięte
            List<int> listId = new List<int>();

            foreach (DietDay day in diet.DietDays)
            {
                var dietDay = _dietRepository.GetDayById(day.Id);

                listId.Add(dietDay.Id);
            }

            // Kaskadowe usuwanie dni dietetycznych
            for (int i = 0; i < listId.Count(); i++)
            {
                var dietDay = _dietRepository.GetDayById(listId[i]);

                if (dietDay == null)
                {
                    response.Errors.Add("Dzień, który chcesz usunąć nie istnieje");
                    return response;
                }

                await _dietRepository.DeleteAsyncDay(dietDay);
            }

            foreach (DietDayBindingModel day in model.DietDayBindingModels)
            {
                DietDay dietDay = new DietDay()
                {
                    DietPlanId = diet.Id,
                    Name = day.Name
                };

                var insertDay = await _dietRepository.InserAsyncDay(dietDay);

                foreach (DietDetailBindingModel detail in day.DietDetailBindingModels)
                {
                    DietDetail dietDetail = new DietDetail()
                    {
                        DietDayId = insertDay.Id,
                        Meal = detail.Meal,
                        Hour = detail.Hour,
                        Dish = detail.Dish,
                        Recipe = detail.Recipe,
                        Comments = detail.Comments
                    };

                    var insertDetail = await _dietRepository.InsertAsyncDetail(dietDetail);

                    foreach (DietProductBindingModel product in detail.DietProductBindingModels)
                    {
                        DietProduct dietProduct = new DietProduct()
                        {
                            DietDetailId = insertDetail.Id,
                            HomeMeasure = product.HomeMeasure,
                            Quantity = product.Quantity,
                            Name = product.Name
                        };

                        var insertProduct = await _dietRepository.InsertAsyncProduct(dietProduct);
                    }
                }
            }

            return response;
        }

        public async Task<ResponseDto<BaseModelDto>> EditProduct(int id, EditDietProductBindingModel model)
        {
            var response = new ResponseDto<BaseModelDto>();

            var product = _dietRepository.GetProductById(id);

            if(product == null)
            {
                response.Errors.Add("Produkt, który chcesz zmodyfikować nie istnieje");
                return response;
            }

            product.HomeMeasure = model.HomeMeasure;
            product.Quantity = model.Quantity;
            product.Name = model.Name;

            await _dietRepository.EditAsyncProduct(product);

            return response;
        }

        public ResponseDto<DietsDto> GetAllDiets()
        {
            var response = new ResponseDto<DietsDto>()
            {
                Object = new DietsDto()
            };

            var diets = _dietRepository.GetAllDiets().ToList();
            response.Object.Diets = _mapper.Map<List<DietPlanDto>>(diets);

            return response;
        }

        public ResponseDto<DietsDto> GetAllDietsUser(int userId)
        {
            var response = new ResponseDto<DietsDto>()
            {
                Object = new DietsDto()
            };

            var diets = _dietRepository.GetAllUserDiets(userId);
            response.Object.Diets = _mapper.Map<List<DietPlanDto>>(diets);

            return response;
        }

        public ResponseDto<DietPlanDto> GetDiet(int id)
        {
            var response = new ResponseDto<DietPlanDto>
            {
                Object = new DietPlanDto()
            };

            var diet = _dietRepository.GetDietById(id);

            if (diet == null)
            {
                response.Errors.Add("Podana dieta nie istnieje");
                return response;
            }

            response.Object = _mapper.Map<DietPlanDto>(diet);

            return response;
        }

        public ResponseDto<SearchResult<DietForSearchDto>> GetPaginationDiets(int userId, SearchBindingModel parametes)
        {
            var result = new ResponseDto<SearchResult<DietForSearchDto>>();

            var diets = _dietRepository.GetByParameters(userId, parametes);

            if (diets.TotalPageCount == 0)
            {
                result.Errors.Add("Nie znaleziono takich planów dietetycznych");
                return result;
            }

            if (parametes.PageNumber > diets.TotalPageCount)
            {
                result.Errors.Add($"Strona {parametes.PageNumber - 1} wykracza poza limit {diets.TotalPageCount - 1}");
                return result;
            }

            result.Object = diets;
            return result;
        }

        public async Task<ResponseDto<BaseModelDto>> InsertDiet(int idUser, int idTrainer, DietPlanBindingModel model)
        {
            var response = new ResponseDto<BaseModelDto>();

            var userId = _repoUser.GetByUserId(idUser);

            if (userId == null)
            {
                response.Errors.Add("Użytkownik, którego chcesz dodać nie istnieje");
                return response;
            }

            var trainerId = _repoUser.GetByUserId(idTrainer);

            if (trainerId == null)
            {
                response.Errors.Add("Wystąpil błąd, spróbuj ponownie później");
                return response;
            }

            var verifyUser = _repoUser.VerifyPupilTrainer(trainerId.Id, userId.Id);

            if (verifyUser == null)
            {
                response.Errors.Add("Trener nie posiada uprawień dla tego podopiecznego");
                return response;
            }

            DietPlan diet = new DietPlan()
            {
                Name = model.Name
            };

            var insertDiet = await _dietRepository.InsertAsync(diet);

            if(insertDiet == null)
            {
                response.Errors.Add("Wystąpił błąd podczas dodawania diety");
                return response;
            }

            foreach (DietDayBindingModel day in model.DietDayBindingModels)
            {
                DietDay dietDay = new DietDay()
                {
                    DietPlanId = insertDiet.Id,
                    Name = day.Name
                };

                var insertDay = await _dietRepository.InserAsyncDay(dietDay);

                foreach (DietDetailBindingModel detail in day.DietDetailBindingModels)
                {
                    DietDetail dietDetail = new DietDetail()
                    {
                        DietDayId = insertDay.Id,
                        Meal = detail.Meal,
                        Hour = detail.Hour,
                        Dish = detail.Dish,
                        Recipe = detail.Recipe,
                        Comments = detail.Comments
                    };

                    var insertDetail = await _dietRepository.InsertAsyncDetail(dietDetail);

                    foreach (DietProductBindingModel product in detail.DietProductBindingModels)
                    {
                        DietProduct dietProduct = new DietProduct()
                        {
                            DietDetailId = insertDetail.Id,
                            HomeMeasure = product.HomeMeasure,
                            Quantity = product.Quantity,
                            Name = product.Name
                        };

                        var insertProduct = await _dietRepository.InsertAsyncProduct(dietProduct);
                    }
                }
            }

            return response;
        }
    }
}
