using Engineer.Models;
using Engineer.Models.BindingModel;
using Engineer.Models.BindingModel.Survey;
using Engineer.Models.Dto;
using Engineer.Models.Dto.Survey;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Engineer.Services.Interface
{
    public interface ISurveyService
    {
        ResponseDto<SearchResult<SurveyForSearchDto>> GetPaginationBiceps(int userId, SearchSurveyBindingModels parametes);
        ResponseDto<SearchResult<SurveyForSearchDto>> GetPaginationBodyFat(int userId, SearchSurveyBindingModels parametes);
        ResponseDto<SearchResult<SurveyForSearchDto>> GetPaginationBodyWeight(int userId, SearchSurveyBindingModels parametes);
        ResponseDto<SearchResult<SurveyForSearchDto>> GetPaginationCalf(int userId, SearchSurveyBindingModels parametes);
        ResponseDto<SearchResult<SurveyForSearchDto>> GetPaginationChest(int userId, SearchSurveyBindingModels parametes);
        ResponseDto<SearchResult<SurveyForSearchDto>> GetPaginationHip(int userId, SearchSurveyBindingModels parametes);
        ResponseDto<SearchResult<SurveyForSearchDto>> GetPaginationThigh(int userId, SearchSurveyBindingModels parametes);

        ResponseDto<SurveyForSearchDto> GetBiceps(int id);
        ResponseDto<SurveyForSearchDto> GetBodyFat(int id);
        ResponseDto<SurveyForSearchDto> GetBodyWeight(int id);
        ResponseDto<SurveyForSearchDto> GetCalf(int id);
        ResponseDto<SurveyForSearchDto> GetChest(int id);
        ResponseDto<SurveyForSearchDto> GetHip(int id);
        ResponseDto<SurveyForSearchDto> GetThigh(int id);

        ResponseDto<CurrentSurveyDto> GetCurrentSurveys(int userId);

        Task<ResponseDto<BaseModelDto>> InsertBiceps(int idUser, SurveyBindingModel model);
        Task<ResponseDto<BaseModelDto>> InsertBodyFat(int idUser, SurveyBindingModel model);
        Task<ResponseDto<BaseModelDto>> InsertBodyWeight(int idUser, SurveyBindingModel model);
        Task<ResponseDto<BaseModelDto>> InsertCalf(int idUser, SurveyBindingModel model);
        Task<ResponseDto<BaseModelDto>> InsertChest(int idUser, SurveyBindingModel model);
        Task<ResponseDto<BaseModelDto>> InsertHip(int idUser, SurveyBindingModel model);
        Task<ResponseDto<BaseModelDto>> InsertThigh(int idUser, SurveyBindingModel model);

        Task<ResponseDto<BaseModelDto>> EditBiceps(int id, SurveyEditBindingModel model);
        Task<ResponseDto<BaseModelDto>> EditBodyFat(int id, SurveyEditBindingModel model);
        Task<ResponseDto<BaseModelDto>> EditBodyWeight(int id, SurveyEditBindingModel model);
        Task<ResponseDto<BaseModelDto>> EditCalf(int id, SurveyEditBindingModel model);
        Task<ResponseDto<BaseModelDto>> EditChest(int id, SurveyEditBindingModel model);
        Task<ResponseDto<BaseModelDto>> EditHip(int id, SurveyEditBindingModel model);
        Task<ResponseDto<BaseModelDto>> EditThigh(int id, SurveyEditBindingModel model);

        Task<ResponseDto<BaseModelDto>> DeleteBiceps(int id);
        Task<ResponseDto<BaseModelDto>> DeleteBodyFat(int id);
        Task<ResponseDto<BaseModelDto>> DeleteBodyWeight(int id);
        Task<ResponseDto<BaseModelDto>> DeleteCalf(int id);
        Task<ResponseDto<BaseModelDto>> DeleteChest(int id);
        Task<ResponseDto<BaseModelDto>> DeleteHip(int id);
        Task<ResponseDto<BaseModelDto>> DeleteThigh(int id);
    }
}
