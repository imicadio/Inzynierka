using AutoMapper;
using Engineer.Models;
using Engineer.Models.BindingModel;
using Engineer.Models.BindingModel.Survey;
using Engineer.Models.Dto;
using Engineer.Models.Dto.Survey;
using Engineer.Models.Models.Survey;
using Engineer.Repositories.Interfaces;
using Engineer.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Engineer.Services.Repository
{
    public class SurveyService : ISurveyService
    {
        private readonly ISurveyRepository _surveyRepository;
        private readonly IMapper _mapper;
        private readonly IDatingRepository _repoUser;

        public SurveyService(ISurveyRepository surveyRepository, IMapper mapper, IDatingRepository repoUser)
        {
            _surveyRepository = surveyRepository;
            _mapper = mapper;
            _repoUser = repoUser;
        }

        public async Task<ResponseDto<BaseModelDto>> DeleteBiceps(int id)
        {
            var response = new ResponseDto<BaseModelDto>();

            var data = _surveyRepository.GetByBicepsId(id);

            if (data == null)
            {
                response.Errors.Add("Trening, który chcesz usunąć nie istnieje");
                return response;
            }

            await _surveyRepository.DeleteAsyncBiceps(data);

            return response;
        }

        public async Task<ResponseDto<BaseModelDto>> DeleteBodyFat(int id)
        {
            var response = new ResponseDto<BaseModelDto>();

            var data = _surveyRepository.GetByBodyFatId(id);

            if (data == null)
            {
                response.Errors.Add("Trening, który chcesz usunąć nie istnieje");
                return response;
            }

            await _surveyRepository.DeleteAsyncBodyFat(data);

            return response;
        }

        public async Task<ResponseDto<BaseModelDto>> DeleteBodyWeight(int id)
        {
            var response = new ResponseDto<BaseModelDto>();

            var data = _surveyRepository.GetByBodyWeightId(id);

            if (data == null)
            {
                response.Errors.Add("Trening, który chcesz usunąć nie istnieje");
                return response;
            }

            await _surveyRepository.DeleteAsyncBodyWeight(data);

            return response;
        }

        public async Task<ResponseDto<BaseModelDto>> DeleteCalf(int id)
        {
            var response = new ResponseDto<BaseModelDto>();

            var data = _surveyRepository.GetByCalfId(id);

            if (data == null)
            {
                response.Errors.Add("Trening, który chcesz usunąć nie istnieje");
                return response;
            }

            await _surveyRepository.DeleteAsyncCalf(data);

            return response;
        }

        public async Task<ResponseDto<BaseModelDto>> DeleteChest(int id)
        {
            var response = new ResponseDto<BaseModelDto>();

            var data = _surveyRepository.GetByChestId(id);

            if (data == null)
            {
                response.Errors.Add("Trening, który chcesz usunąć nie istnieje");
                return response;
            }

            await _surveyRepository.DeleteAsyncChest(data);

            return response;
        }

        public async Task<ResponseDto<BaseModelDto>> DeleteHip(int id)
        {
            var response = new ResponseDto<BaseModelDto>();

            var data = _surveyRepository.GetByHipId(id);

            if (data == null)
            {
                response.Errors.Add("Trening, który chcesz usunąć nie istnieje");
                return response;
            }

            await _surveyRepository.DeleteAsyncHip(data);

            return response;
        }

        public async Task<ResponseDto<BaseModelDto>> DeleteThigh(int id)
        {
            var response = new ResponseDto<BaseModelDto>();

            var data = _surveyRepository.GetByThighId(id);

            if (data == null)
            {
                response.Errors.Add("Trening, który chcesz usunąć nie istnieje");
                return response;
            }

            await _surveyRepository.DeleteAsyncThigh(data);

            return response;
        }

        public async Task<ResponseDto<BaseModelDto>> EditBiceps(int id, SurveyEditBindingModel model)
        {
            var response = new ResponseDto<BaseModelDto>();

            var data = _surveyRepository.GetByBicepsId(id);

            if (data == null)
            {
                response.Errors.Add("Rozmiar, który chcesz zmodyfikować nie istnieje.");
                return response;
            }

            data.Size = model.Size;
            data.DateAdded = model.DateAdded;

            await _surveyRepository.EditBiceps(data);

            return response;
        }

        public async Task<ResponseDto<BaseModelDto>> EditBodyFat(int id, SurveyEditBindingModel model)
        {
            var response = new ResponseDto<BaseModelDto>();

            var data = _surveyRepository.GetByBodyFatId(id);

            if (data == null)
            {
                response.Errors.Add("Rozmiar, który chcesz zmodyfikować nie istnieje.");
                return response;
            }

            data.Size = model.Size;
            data.DateAdded = model.DateAdded;

            await _surveyRepository.EditBodyFat(data);

            return response;
        }

        public async Task<ResponseDto<BaseModelDto>> EditBodyWeight(int id, SurveyEditBindingModel model)
        {
            var response = new ResponseDto<BaseModelDto>();

            var data = _surveyRepository.GetByBodyWeightId(id);

            if (data == null)
            {
                response.Errors.Add("Rozmiar, który chcesz zmodyfikować nie istnieje.");
                return response;
            }

            data.Size = model.Size;
            data.DateAdded = model.DateAdded;

            await _surveyRepository.EditBodyWeight(data);

            return response;
        }

        public async Task<ResponseDto<BaseModelDto>> EditCalf(int id, SurveyEditBindingModel model)
        {
            var response = new ResponseDto<BaseModelDto>();

            var data = _surveyRepository.GetByCalfId(id);

            if (data == null)
            {
                response.Errors.Add("Rozmiar, który chcesz zmodyfikować nie istnieje.");
                return response;
            }

            data.Size = model.Size;
            data.DateAdded = model.DateAdded;

            await _surveyRepository.EditCalf(data);

            return response;
        }

        public async Task<ResponseDto<BaseModelDto>> EditChest(int id, SurveyEditBindingModel model)
        {
            var response = new ResponseDto<BaseModelDto>();

            var data = _surveyRepository.GetByChestId(id);

            if (data == null)
            {
                response.Errors.Add("Rozmiar, który chcesz zmodyfikować nie istnieje.");
                return response;
            }

            data.Size = model.Size;
            data.DateAdded = model.DateAdded;

            await _surveyRepository.EditChest(data);

            return response;
        }

        public async Task<ResponseDto<BaseModelDto>> EditHip(int id, SurveyEditBindingModel model)
        {
            var response = new ResponseDto<BaseModelDto>();

            var data = _surveyRepository.GetByHipId(id);

            if (data == null)
            {
                response.Errors.Add("Rozmiar, który chcesz zmodyfikować nie istnieje.");
                return response;
            }

            data.Size = model.Size;
            data.DateAdded = model.DateAdded;

            await _surveyRepository.EditHip(data);

            return response;
        }

        public async Task<ResponseDto<BaseModelDto>> EditThigh(int id, SurveyEditBindingModel model)
        {
            var response = new ResponseDto<BaseModelDto>();

            var data = _surveyRepository.GetByThighId(id);

            if (data == null)
            {
                response.Errors.Add("Rozmiar, który chcesz zmodyfikować nie istnieje.");
                return response;
            }

            data.Size = model.Size;
            data.DateAdded = model.DateAdded;

            await _surveyRepository.EditThigh(data);

            return response;
        }

        public ResponseDto<SurveyForSearchDto> GetBiceps(int id)
        {
            var response = new ResponseDto<SurveyForSearchDto>
            {
                Object = new SurveyForSearchDto()
            };

            var data = _surveyRepository.GetByBicepsId(id);

            if (data == null)
            {
                response.Errors.Add("Podany trening nie istnieje, utworz nowy trening");
                return response;
            }

            response.Object = _mapper.Map<SurveyForSearchDto>(data);

            return response;
        }

        public ResponseDto<SurveyForSearchDto> GetBodyFat(int id)
        {
            var response = new ResponseDto<SurveyForSearchDto>
            {
                Object = new SurveyForSearchDto()
            };

            var data = _surveyRepository.GetByBodyFatId(id);

            if (data == null)
            {
                response.Errors.Add("Podany trening nie istnieje, utworz nowy trening");
                return response;
            }

            response.Object = _mapper.Map<SurveyForSearchDto>(data);

            return response;
        }

        public ResponseDto<SurveyForSearchDto> GetBodyWeight(int id)
        {
            var response = new ResponseDto<SurveyForSearchDto>
            {
                Object = new SurveyForSearchDto()
            };

            var data = _surveyRepository.GetByBodyWeightId(id);

            if (data == null)
            {
                response.Errors.Add("Podany trening nie istnieje, utworz nowy trening");
                return response;
            }

            response.Object = _mapper.Map<SurveyForSearchDto>(data);

            return response;
        }

        public ResponseDto<SurveyForSearchDto> GetCalf(int id)
        {
            var response = new ResponseDto<SurveyForSearchDto>
            {
                Object = new SurveyForSearchDto()
            };

            var data = _surveyRepository.GetByCalfId(id);

            if (data == null)
            {
                response.Errors.Add("Podany trening nie istnieje, utworz nowy trening");
                return response;
            }

            response.Object = _mapper.Map<SurveyForSearchDto>(data);

            return response;
        }

        public ResponseDto<SurveyForSearchDto> GetChest(int id)
        {
            var response = new ResponseDto<SurveyForSearchDto>
            {
                Object = new SurveyForSearchDto()
            };

            var data = _surveyRepository.GetByChestId(id);

            if (data == null)
            {
                response.Errors.Add("Podany trening nie istnieje, utworz nowy trening");
                return response;
            }

            response.Object = _mapper.Map<SurveyForSearchDto>(data);

            return response;
        }

        public ResponseDto<CurrentSurveyDto> GetCurrentSurveys(int userId)
        {
            var response = new ResponseDto<CurrentSurveyDto>
            {
                Object = new CurrentSurveyDto()
            };

            List<SurveyForSearchDto> typo = new List<SurveyForSearchDto>();

            var currentBodyWeight = _surveyRepository.GetCurrentBodyWeight(userId);
            if(currentBodyWeight != null)
                typo.Add(_mapper.Map<SurveyForSearchDto>(currentBodyWeight));
            else
            {
                SurveyForSearchDto puste = new SurveyForSearchDto()
                {
                    Size = 0
                };
                typo.Add(puste);
            }
            typo[0].UserName = "Masa ciała";

            var currentBodyFat = _surveyRepository.GetCurrentBodyFat(userId);
            if (currentBodyWeight != null)
                typo.Add(_mapper.Map<SurveyForSearchDto>(currentBodyFat));
            else
            {
                SurveyForSearchDto puste = new SurveyForSearchDto()
                {
                    Size = 0
                };
                typo.Add(puste);
            }            
            typo[1].UserName = "Tkanka tłuszczowa";

            var currentBiceps = _surveyRepository.GetCurrentBiceps(userId);
            if (currentBodyWeight != null)
                typo.Add(_mapper.Map<SurveyForSearchDto>(currentBiceps));
            else
            {
                SurveyForSearchDto puste = new SurveyForSearchDto()
                {
                    Size = 0
                };
                typo.Add(puste);
            }            
            typo[2].UserName = "Biceps";

            var currentChest = _surveyRepository.GetCurrentChest(userId);
            if (currentBodyWeight != null)
                typo.Add(_mapper.Map<SurveyForSearchDto>(currentChest));
            else
            {
                SurveyForSearchDto puste = new SurveyForSearchDto()
                {
                    Size = 0
                };
                typo.Add(puste);
            }            
            typo[3].UserName = "Klatka piersiowa";

            var currentHip = _surveyRepository.GetCurrentHip(userId);
            if (currentBodyWeight != null)
                typo.Add(_mapper.Map<SurveyForSearchDto>(currentHip));
            else
            {
                SurveyForSearchDto puste = new SurveyForSearchDto()
                {
                    Size = 0
                };
                typo.Add(puste);
            }            
            typo[4].UserName = "Biodra";

            var currentThigh = _surveyRepository.GetCurrentThigh(userId);
            if (currentBodyWeight != null)
                typo.Add(_mapper.Map<SurveyForSearchDto>(currentThigh));
            else
            {
                SurveyForSearchDto puste = new SurveyForSearchDto()
                {
                    Size = 0
                };
                typo.Add(puste);
            }            
            typo[5].UserName = "Łydka";

            var currentCalf = _surveyRepository.GetCurrentCalf(userId);
            if (currentBodyWeight != null)
                typo.Add(_mapper.Map<SurveyForSearchDto>(currentCalf));
            else
            {
                SurveyForSearchDto puste = new SurveyForSearchDto()
                {
                    Size = 0
                };
                typo.Add(puste);
            }            
            typo[6].UserName = "Udo";

            response.Object.currentSurvey = _mapper.Map<List<SurveyForSearchDto>>(typo);

            return response;
        }

        public ResponseDto<SurveyForSearchDto> GetHip(int id)
        {
            var response = new ResponseDto<SurveyForSearchDto>
            {
                Object = new SurveyForSearchDto()
            };

            var data = _surveyRepository.GetByHipId(id);

            if (data == null)
            {
                response.Errors.Add("Podany trening nie istnieje, utworz nowy trening");
                return response;
            }

            response.Object = _mapper.Map<SurveyForSearchDto>(data);

            return response;
        }

        public ResponseDto<SearchResult<SurveyForSearchDto>> GetPaginationBiceps(int userId, SearchSurveyBindingModels parametes)
        {
            var result = new ResponseDto<SearchResult<SurveyForSearchDto>>();

            var data = _surveyRepository.GetByBiceps(userId, parametes);

            if (data.TotalPageCount == 0)
            {
                result.Errors.Add("Nie znaleziono takich marek piw");
                return result;
            }

            if (parametes.PageNumber > data.TotalPageCount)
            {
                result.Errors.Add($"Strona {parametes.PageNumber - 1} wykracza poza limit {data.TotalPageCount - 1}");
                return result;
            }

            result.Object = data;
            return result;
        }

        public ResponseDto<SearchResult<SurveyForSearchDto>> GetPaginationBodyFat(int userId, SearchSurveyBindingModels parametes)
        {
            var result = new ResponseDto<SearchResult<SurveyForSearchDto>>();

            var data = _surveyRepository.GetByBodyFat(userId, parametes);

            if (data.TotalPageCount == 0)
            {
                result.Errors.Add("Nie znaleziono takich marek piw");
                return result;
            }

            if (parametes.PageNumber > data.TotalPageCount)
            {
                result.Errors.Add($"Strona {parametes.PageNumber - 1} wykracza poza limit {data.TotalPageCount - 1}");
                return result;
            }

            result.Object = data;
            return result;
        }

        public ResponseDto<SearchResult<SurveyForSearchDto>> GetPaginationBodyWeight(int userId, SearchSurveyBindingModels parametes)
        {
            var result = new ResponseDto<SearchResult<SurveyForSearchDto>>();

            var data = _surveyRepository.GetByBodyWeight(userId, parametes);

            if (data.TotalPageCount == 0)
            {
                result.Errors.Add("Nie znaleziono takich marek piw");
                return result;
            }

            if (parametes.PageNumber > data.TotalPageCount)
            {
                result.Errors.Add($"Strona {parametes.PageNumber - 1} wykracza poza limit {data.TotalPageCount - 1}");
                return result;
            }

            result.Object = data;
            return result;
        }

        public ResponseDto<SearchResult<SurveyForSearchDto>> GetPaginationCalf(int userId, SearchSurveyBindingModels parametes)
        {
            var result = new ResponseDto<SearchResult<SurveyForSearchDto>>();

            var data = _surveyRepository.GetByCalf(userId, parametes);

            if (data.TotalPageCount == 0)
            {
                result.Errors.Add("Nie znaleziono takich marek piw");
                return result;
            }

            if (parametes.PageNumber > data.TotalPageCount)
            {
                result.Errors.Add($"Strona {parametes.PageNumber - 1} wykracza poza limit {data.TotalPageCount - 1}");
                return result;
            }

            result.Object = data;
            return result;
        }

        public ResponseDto<SearchResult<SurveyForSearchDto>> GetPaginationChest(int userId, SearchSurveyBindingModels parametes)
        {
            var result = new ResponseDto<SearchResult<SurveyForSearchDto>>();

            var data = _surveyRepository.GetByChest(userId, parametes);

            if (data.TotalPageCount == 0)
            {
                result.Errors.Add("Nie znaleziono takich marek piw");
                return result;
            }

            if (parametes.PageNumber > data.TotalPageCount)
            {
                result.Errors.Add($"Strona {parametes.PageNumber - 1} wykracza poza limit {data.TotalPageCount - 1}");
                return result;
            }

            result.Object = data;
            return result;
        }

        public ResponseDto<SearchResult<SurveyForSearchDto>> GetPaginationHip(int userId, SearchSurveyBindingModels parametes)
        {
            var result = new ResponseDto<SearchResult<SurveyForSearchDto>>();

            var data = _surveyRepository.GetByHip(userId, parametes);

            if (data.TotalPageCount == 0)
            {
                result.Errors.Add("Nie znaleziono takich marek piw");
                return result;
            }

            if (parametes.PageNumber > data.TotalPageCount)
            {
                result.Errors.Add($"Strona {parametes.PageNumber - 1} wykracza poza limit {data.TotalPageCount - 1}");
                return result;
            }

            result.Object = data;
            return result;
        }

        public ResponseDto<SearchResult<SurveyForSearchDto>> GetPaginationThigh(int userId, SearchSurveyBindingModels parametes)
        {
            var result = new ResponseDto<SearchResult<SurveyForSearchDto>>();

            var data = _surveyRepository.GetByThigh(userId, parametes);

            if (data.TotalPageCount == 0)
            {
                result.Errors.Add("Nie znaleziono takich marek piw");
                return result;
            }

            if (parametes.PageNumber > data.TotalPageCount)
            {
                result.Errors.Add($"Strona {parametes.PageNumber - 1} wykracza poza limit {data.TotalPageCount - 1}");
                return result;
            }

            result.Object = data;
            return result;
        }

        public ResponseDto<SurveyForSearchDto> GetThigh(int id)
        {
            var response = new ResponseDto<SurveyForSearchDto>
            {
                Object = new SurveyForSearchDto()
            };

            var data = _surveyRepository.GetByThighId(id);

            if (data == null)
            {
                response.Errors.Add("Podany trening nie istnieje, utworz nowy trening");
                return response;
            }

            response.Object = _mapper.Map<SurveyForSearchDto>(data);

            return response;
        }

        public async Task<ResponseDto<BaseModelDto>> InsertBiceps(int idUser, SurveyBindingModel model)
        {
            var response = new ResponseDto<BaseModelDto>();

            var userId = _repoUser.GetByUserId(idUser);

            if (userId == null)
            {
                response.Errors.Add("Użytkownik, którego chcesz dodać nie istnieje");
                return response;
            } 

            var trainerId = _repoUser.GetTrainer(userId.Id);

            int _trainerId = trainerId.TrainerId.Value;

            if (trainerId == null)
            {
                response.Errors.Add("Wystąpil błąd, spróbuj ponownie później");
                return response;
            }

            var verifyUser = _repoUser.VerifyPupilTrainer(_trainerId, userId.Id);

            if (verifyUser == null)
            {
                response.Errors.Add("Trener nie posiada uprawień dla tego podopiecznego");
                return response;
            }

            var survey = _surveyRepository.GetSurvey(userId.Id);

            Biceps biceps = new Biceps()
            {
                Size = model.Size,
                TrainerId = _trainerId,
                UserId = userId.Id,
                UserName = userId.UserName,
                DateAdded = DateTime.Now,
                SurveyId = survey.Id
            };

            var insert = await _surveyRepository.InsertBiceps(biceps);

            if (insert == null)
            {
                response.Errors.Add("Wystąpił błąd podczas dodawania treningu");
                return response;
            }

            return response;
        }

        public async Task<ResponseDto<BaseModelDto>> InsertBodyFat(int idUser, SurveyBindingModel model)
        {
            var response = new ResponseDto<BaseModelDto>();

            var userId = _repoUser.GetByUserId(idUser);

            if (userId == null)
            {
                response.Errors.Add("Użytkownik, którego chcesz dodać nie istnieje");
                return response;
            }

            var trainerId = _repoUser.GetTrainer(userId.Id);

            int _trainerId = trainerId.TrainerId.Value;

            if (trainerId == null)
            {
                response.Errors.Add("Wystąpil błąd, spróbuj ponownie później");
                return response;
            }

            var verifyUser = _repoUser.VerifyPupilTrainer(_trainerId, userId.Id);

            if (verifyUser == null)
            {
                response.Errors.Add("Trener nie posiada uprawień dla tego podopiecznego");
                return response;
            }

            var survey = _surveyRepository.GetSurvey(userId.Id);

            BodyFat data = new BodyFat()
            {
                Size = model.Size,
                TrainerId = _trainerId,
                UserId = userId.Id,
                UserName = userId.UserName,
                DateAdded = DateTime.Now,
                SurveyId = survey.Id
            };

            var insert = await _surveyRepository.InsertBodyFat(data);

            if (insert == null)
            {
                response.Errors.Add("Wystąpił błąd podczas dodawania treningu");
                return response;
            }

            return response;
        }

        public async Task<ResponseDto<BaseModelDto>> InsertBodyWeight(int idUser, SurveyBindingModel model)
        {
            var response = new ResponseDto<BaseModelDto>();

            var userId = _repoUser.GetByUserId(idUser);

            if (userId == null)
            {
                response.Errors.Add("Użytkownik, którego chcesz dodać nie istnieje");
                return response;
            }

            var trainerId = _repoUser.GetTrainer(userId.Id);

            int _trainerId = trainerId.TrainerId.Value;

            if (trainerId == null)
            {
                response.Errors.Add("Wystąpil błąd, spróbuj ponownie później");
                return response;
            }

            var verifyUser = _repoUser.VerifyPupilTrainer(_trainerId, userId.Id);

            if (verifyUser == null)
            {
                response.Errors.Add("Trener nie posiada uprawień dla tego podopiecznego");
                return response;
            }

            var survey = _surveyRepository.GetSurvey(userId.Id);

            BodyWeight data = new BodyWeight()
            {
                Size = model.Size,
                TrainerId = _trainerId,
                UserId = userId.Id,
                UserName = userId.UserName,
                DateAdded = DateTime.Now,
                SurveyId = survey.Id
            };

            var insert = await _surveyRepository.InsertBodyWeight(data);

            if (insert == null)
            {
                response.Errors.Add("Wystąpił błąd podczas dodawania treningu");
                return response;
            }

            return response;
        }

        public async Task<ResponseDto<BaseModelDto>> InsertCalf(int idUser, SurveyBindingModel model)
        {
            var response = new ResponseDto<BaseModelDto>();

            var userId = _repoUser.GetByUserId(idUser);

            if (userId == null)
            {
                response.Errors.Add("Użytkownik, którego chcesz dodać nie istnieje");
                return response;
            }

            var trainerId = _repoUser.GetTrainer(userId.Id);

            int _trainerId = trainerId.TrainerId.Value;

            if (trainerId == null)
            {
                response.Errors.Add("Wystąpil błąd, spróbuj ponownie później");
                return response;
            }

            var verifyUser = _repoUser.VerifyPupilTrainer(_trainerId, userId.Id);

            if (verifyUser == null)
            {
                response.Errors.Add("Trener nie posiada uprawień dla tego podopiecznego");
                return response;
            }

            var survey = _surveyRepository.GetSurvey(userId.Id);

            Calf data = new Calf()
            {
                Size = model.Size,
                TrainerId = _trainerId,
                UserId = userId.Id,
                UserName = userId.UserName,
                DateAdded = DateTime.Now,
                SurveyId = survey.Id
            };

            var insert = await _surveyRepository.InsertCalf(data);

            if (insert == null)
            {
                response.Errors.Add("Wystąpił błąd podczas dodawania treningu");
                return response;
            }

            return response;
        }

        public async Task<ResponseDto<BaseModelDto>> InsertChest(int idUser, SurveyBindingModel model)
        {
            var response = new ResponseDto<BaseModelDto>();

            var userId = _repoUser.GetByUserId(idUser);

            if (userId == null)
            {
                response.Errors.Add("Użytkownik, którego chcesz dodać nie istnieje");
                return response;
            }

            var trainerId = _repoUser.GetTrainer(userId.Id);

            int _trainerId = trainerId.TrainerId.Value;

            if (trainerId == null)
            {
                response.Errors.Add("Wystąpil błąd, spróbuj ponownie później");
                return response;
            }

            var verifyUser = _repoUser.VerifyPupilTrainer(_trainerId, userId.Id);

            if (verifyUser == null)
            {
                response.Errors.Add("Trener nie posiada uprawień dla tego podopiecznego");
                return response;
            }

            var survey = _surveyRepository.GetSurvey(userId.Id);

            Chest data = new Chest()
            {
                Size = model.Size,
                TrainerId = _trainerId,
                UserId = userId.Id,
                UserName = userId.UserName,
                DateAdded = DateTime.Now,
                SurveyId = survey.Id
            };

            var insert = await _surveyRepository.InsertChest(data);

            if (insert == null)
            {
                response.Errors.Add("Wystąpił błąd podczas dodawania treningu");
                return response;
            }

            return response;
        }

        public async Task<ResponseDto<BaseModelDto>> InsertHip(int idUser, SurveyBindingModel model)
        {
            var response = new ResponseDto<BaseModelDto>();

            var userId = _repoUser.GetByUserId(idUser);

            if (userId == null)
            {
                response.Errors.Add("Użytkownik, którego chcesz dodać nie istnieje");
                return response;
            }

            var trainerId = _repoUser.GetTrainer(userId.Id);

            int _trainerId = trainerId.TrainerId.Value;

            if (trainerId == null)
            {
                response.Errors.Add("Wystąpil błąd, spróbuj ponownie później");
                return response;
            }

            var verifyUser = _repoUser.VerifyPupilTrainer(_trainerId, userId.Id);

            if (verifyUser == null)
            {
                response.Errors.Add("Trener nie posiada uprawień dla tego podopiecznego");
                return response;
            }

            var survey = _surveyRepository.GetSurvey(userId.Id);
            Hip data = new Hip()
            {
                Size = model.Size,
                TrainerId = _trainerId,
                UserId = userId.Id,
                UserName = userId.UserName,
                DateAdded = DateTime.Now,
                SurveyId = survey.Id
            };

            var insert = await _surveyRepository.InsertHip(data);

            if (insert == null)
            {
                response.Errors.Add("Wystąpił błąd podczas dodawania treningu");
                return response;
            }

            return response;
        }

        public async Task<ResponseDto<BaseModelDto>> InsertThigh(int idUser, SurveyBindingModel model)
        {
            var response = new ResponseDto<BaseModelDto>();

            var userId = _repoUser.GetByUserId(idUser);

            if (userId == null)
            {
                response.Errors.Add("Użytkownik, którego chcesz dodać nie istnieje");
                return response;
            }

            var trainerId = _repoUser.GetTrainer(userId.Id);

            int _trainerId = trainerId.TrainerId.Value;

            if (trainerId == null)
            {
                response.Errors.Add("Wystąpil błąd, spróbuj ponownie później");
                return response;
            }

            var verifyUser = _repoUser.VerifyPupilTrainer(_trainerId, userId.Id);

            if (verifyUser == null)
            {
                response.Errors.Add("Trener nie posiada uprawień dla tego podopiecznego");
                return response;
            }

            var survey = _surveyRepository.GetSurvey(userId.Id);

            Thigh data = new Thigh()
            {
                Size = model.Size,
                TrainerId = _trainerId,
                UserId = userId.Id,
                UserName = userId.UserName,
                DateAdded = DateTime.Now,
                SurveyId = survey.Id
            };

            var insert = await _surveyRepository.InsertThigh(data);

            if (insert == null)
            {
                response.Errors.Add("Wystąpił błąd podczas dodawania treningu");
                return response;
            }

            return response;
        }
    }
}
