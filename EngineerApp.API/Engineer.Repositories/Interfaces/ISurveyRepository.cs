using Engineer.Models.BindingModel;
using Engineer.Models.Dto;
using Engineer.Models.Dto.Survey;
using Engineer.Models.Models.Survey;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Engineer.Repositories.Interfaces
{
    public interface ISurveyRepository
    {
        // Pagination
        SearchResult<SurveyForSearchDto> GetByBiceps(int userId, SearchSurveyBindingModels parametes);
        SearchResult<SurveyForSearchDto> GetByBodyFat(int userId, SearchSurveyBindingModels parametes);
        SearchResult<SurveyForSearchDto> GetByBodyWeight(int userId, SearchSurveyBindingModels parametes);
        SearchResult<SurveyForSearchDto> GetByCalf(int userId, SearchSurveyBindingModels parametes);
        SearchResult<SurveyForSearchDto> GetByChest(int userId, SearchSurveyBindingModels parametes);
        SearchResult<SurveyForSearchDto> GetByHip(int userId, SearchSurveyBindingModels parametes);
        SearchResult<SurveyForSearchDto> GetByThigh(int userId, SearchSurveyBindingModels parametes);

        // CRUD
        Task<Surveyy> InsertSurvey(Surveyy survey);
        Surveyy GetSurvey(int userId);

        Biceps GetByBicepsId(int id);
        BodyFat GetByBodyFatId(int id);
        BodyWeight GetByBodyWeightId(int id);
        Calf GetByCalfId(int id);
        Chest GetByChestId(int id);
        Hip GetByHipId(int id);
        Thigh GetByThighId(int id);


        Task<Biceps> InsertBiceps(Biceps data);
        Task<BodyFat> InsertBodyFat(BodyFat data);
        Task<BodyWeight> InsertBodyWeight(BodyWeight data);
        Task<Calf> InsertCalf(Calf data);
        Task<Chest> InsertChest(Chest data);
        Task<Hip> InsertHip(Hip data);
        Task<Thigh> InsertThigh(Thigh data);

        Task EditBiceps(Biceps data);
        Task EditBodyFat(BodyFat data);
        Task EditBodyWeight(BodyWeight data);
        Task EditCalf(Calf data);
        Task EditChest(Chest data);
        Task EditHip(Hip data);
        Task EditThigh(Thigh data);

        Task DeleteAsyncBiceps(Biceps data);
        Task DeleteAsyncBodyFat(BodyFat data);
        Task DeleteAsyncBodyWeight(BodyWeight data);
        Task DeleteAsyncCalf(Calf data);
        Task DeleteAsyncChest(Chest data);
        Task DeleteAsyncHip(Hip data);
        Task DeleteAsyncThigh(Thigh data);
    }
}
