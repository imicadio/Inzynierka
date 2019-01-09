using Engineer.Models.BindingModel;
using Engineer.Models.Dto;
using Engineer.Models.Dto.Survey;
using Engineer.Models.Models.Survey;
using Engineer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engineer.Repositories.Repositories
{
    public class SurveyRepository : ISurveyRepository
    {
        private readonly DataContext _context;

        public SurveyRepository(DataContext context)
        {
            _context = context;
        }

        public async Task DeleteAsyncBiceps(Biceps data)
        {
            _context.Bicepss.Remove(data);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsyncBodyFat(BodyFat data)
        {
            _context.BodyFats.Remove(data);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsyncBodyWeight(BodyWeight data)
        {
            _context.BodyWeights.Remove(data);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsyncCalf(Calf data)
        {
            _context.Calfs.Remove(data);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsyncChest(Chest data)
        {
            _context.Chests.Remove(data);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsyncHip(Hip data)
        {
            _context.Hips.Remove(data);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsyncThigh(Thigh data)
        {
            _context.Thighs.Remove(data);
            await _context.SaveChangesAsync();
        }

        public async Task EditBiceps(Biceps data)
        {
            _context.Bicepss.Update(data);
            await _context.SaveChangesAsync();
        }

        public async Task EditBodyFat(BodyFat data)
        {
            _context.BodyFats.Update(data);
            await _context.SaveChangesAsync();
        }

        public async Task EditBodyWeight(BodyWeight data)
        {
            _context.BodyWeights.Update(data);
            await _context.SaveChangesAsync();
        }

        public async Task EditCalf(Calf data)
        {
            _context.Calfs.Update(data);
            await _context.SaveChangesAsync();
        }

        public async Task EditChest(Chest data)
        {
            _context.Chests.Update(data);
            await _context.SaveChangesAsync();
        }

        public async Task EditHip(Hip data)
        {
            _context.Hips.Update(data);
            await _context.SaveChangesAsync();
        }

        public async Task EditThigh(Thigh data)
        {
            _context.Thighs.Update(data);
            await _context.SaveChangesAsync();
        }

        public SearchResult<SurveyForSearchDto> GetByBiceps(int userId, SearchSurveyBindingModels parametes)
        {
            IEnumerable<Biceps> biceps;

            if (parametes.Query != null)
            {
                biceps = _context.Bicepss.Where(b => ((b.UserId == userId) || (b.TrainerId == userId)) && ((b.UserName.Contains(parametes.Query)))).ToList();
            }
            else
            {
                biceps = _context.Bicepss.Where(u => u.UserId == userId || u.TrainerId == userId).ToList();
            }

            var totalPages = (int)Math.Ceiling((decimal)biceps.Count() / parametes.Limit);

            var countList = (int)Math.Ceiling((decimal)biceps.Count());

            var property = typeof(Biceps).GetProperty(parametes.Sort.FirstCharToUpper());

            if (property == null)
            {
                var defaultParameters = new SearchSurveyBindingModels();
                property = typeof(Biceps).GetProperty(defaultParameters.Sort);
            }

            biceps = parametes.Ascending
                ? biceps.OrderBy(b => property.GetValue(b))
                : biceps.OrderByDescending(b => property.GetValue(b));

            biceps = biceps.Skip(parametes.Limit * (parametes.PageNumber - 1)).Take(parametes.Limit);

            var result = new SearchResult<SurveyForSearchDto>();
            var surveyForSearch = new List<SurveyForSearchDto>();
            biceps.ToList().ForEach(b =>
                surveyForSearch.Add(new SurveyForSearchDto
                {
                    Id = b.Id,
                    DateAdded = b.DateAdded,                    
                    Size = b.Size,
                    TrainerId = b.TrainerId,
                    UserId = b.UserId,
                    UserName = b.UserName
                }
            ));

            result.Count = countList;
            result.CurrentPage = parametes.PageNumber;
            result.TotalPageCount = totalPages;
            result.Results = surveyForSearch;

            return result;
        }

        public Biceps GetByBicepsId(int id)
        {
            return _context.Bicepss.SingleOrDefault(s => s.Id == id);
        }

        public SearchResult<SurveyForSearchDto> GetByBodyFat(int userId, SearchSurveyBindingModels parametes)
        {
            IEnumerable<BodyFat> bodyFat;

            if (parametes.Query != null)
            {
                bodyFat = _context.BodyFats.Where(b => ((b.UserId == userId) || (b.TrainerId == userId)) && ((b.UserName.Contains(parametes.Query)))).ToList();
            }
            else
            {
                bodyFat = _context.BodyFats.Where(u => u.UserId == userId || u.TrainerId == userId).ToList();
            }

            var totalPages = (int)Math.Ceiling((decimal)bodyFat.Count() / parametes.Limit);

            var countList = (int)Math.Ceiling((decimal)bodyFat.Count());

            var property = typeof(BodyFat).GetProperty(parametes.Sort.FirstCharToUpper());

            if (property == null)
            {
                var defaultParameters = new SearchSurveyBindingModels();
                property = typeof(BodyFat).GetProperty(defaultParameters.Sort);
            }

            bodyFat = parametes.Ascending
                ? bodyFat.OrderBy(b => property.GetValue(b))
                : bodyFat.OrderByDescending(b => property.GetValue(b));

            bodyFat = bodyFat.Skip(parametes.Limit * (parametes.PageNumber - 1)).Take(parametes.Limit);

            var result = new SearchResult<SurveyForSearchDto>();
            var surveyForSearch = new List<SurveyForSearchDto>();
            bodyFat.ToList().ForEach(b =>
                surveyForSearch.Add(new SurveyForSearchDto
                {
                    Id = b.Id,
                    DateAdded = b.DateAdded,
                    Size = b.Size,
                    TrainerId = b.TrainerId,
                    UserName = b.UserName
                }
            ));

            result.Count = countList;
            result.CurrentPage = parametes.PageNumber;
            result.TotalPageCount = totalPages;
            result.Results = surveyForSearch;

            return result;
        }

        public BodyFat GetByBodyFatId(int id)
        {
            return _context.BodyFats.SingleOrDefault(s => s.Id == id);
        }

        public SearchResult<SurveyForSearchDto> GetByBodyWeight(int userId, SearchSurveyBindingModels parametes)
        {
            IEnumerable<BodyWeight> bodyWeights;

            if (parametes.Query != null)
            {
                bodyWeights = _context.BodyWeights.Where(b => ((b.UserId == userId) || (b.TrainerId == userId)) && ((b.UserName.Contains(parametes.Query)))).ToList();
            }
            else
            {
                bodyWeights = _context.BodyWeights.Where(u => u.UserId == userId || u.TrainerId == userId).ToList();
            }

            var totalPages = (int)Math.Ceiling((decimal)bodyWeights.Count() / parametes.Limit);

            var countList = (int)Math.Ceiling((decimal)bodyWeights.Count());

            var property = typeof(BodyWeight).GetProperty(parametes.Sort.FirstCharToUpper());

            if (property == null)
            {
                var defaultParameters = new SearchSurveyBindingModels();
                property = typeof(BodyWeight).GetProperty(defaultParameters.Sort);
            }

            bodyWeights = parametes.Ascending
                ? bodyWeights.OrderBy(b => property.GetValue(b))
                : bodyWeights.OrderByDescending(b => property.GetValue(b));

            bodyWeights = bodyWeights.Skip(parametes.Limit * (parametes.PageNumber - 1)).Take(parametes.Limit);

            var result = new SearchResult<SurveyForSearchDto>();
            var surveyForSearch = new List<SurveyForSearchDto>();
            bodyWeights.ToList().ForEach(b =>
                surveyForSearch.Add(new SurveyForSearchDto
                {
                    Id = b.Id,
                    DateAdded = b.DateAdded,
                    Size = b.Size,
                    TrainerId = b.TrainerId,
                    UserName = b.UserName
                }
            ));

            result.Count = countList;
            result.CurrentPage = parametes.PageNumber;
            result.TotalPageCount = totalPages;
            result.Results = surveyForSearch;

            return result;
        }

        public BodyWeight GetByBodyWeightId(int id)
        {
            return _context.BodyWeights.SingleOrDefault(s => s.Id == id);
        }

        public SearchResult<SurveyForSearchDto> GetByCalf(int userId, SearchSurveyBindingModels parametes)
        {
            IEnumerable<Calf> calf;

            if (parametes.Query != null)
            {
                calf = _context.Calfs.Where(b => ((b.UserId == userId) || (b.TrainerId == userId)) && ((b.UserName.Contains(parametes.Query)))).ToList();
            }
            else
            {
                calf = _context.Calfs.Where(u => u.UserId == userId || u.TrainerId == userId).ToList();
            }

            var totalPages = (int)Math.Ceiling((decimal)calf.Count() / parametes.Limit);

            var countList = (int)Math.Ceiling((decimal)calf.Count());

            var property = typeof(Calf).GetProperty(parametes.Sort.FirstCharToUpper());

            if (property == null)
            {
                var defaultParameters = new SearchSurveyBindingModels();
                property = typeof(Calf).GetProperty(defaultParameters.Sort);
            }

            calf = parametes.Ascending
                ? calf.OrderBy(b => property.GetValue(b))
                : calf.OrderByDescending(b => property.GetValue(b));

            calf = calf.Skip(parametes.Limit * (parametes.PageNumber - 1)).Take(parametes.Limit);

            var result = new SearchResult<SurveyForSearchDto>();
            var surveyForSearch = new List<SurveyForSearchDto>();
            calf.ToList().ForEach(b =>
                surveyForSearch.Add(new SurveyForSearchDto
                {
                    Id = b.Id,
                    DateAdded = b.DateAdded,
                    Size = b.Size,
                    TrainerId = b.TrainerId,
                    UserName = b.UserName
                }
            ));

            result.Count = countList;
            result.CurrentPage = parametes.PageNumber;
            result.TotalPageCount = totalPages;
            result.Results = surveyForSearch;

            return result;
        }

        public Calf GetByCalfId(int id)
        {
            return _context.Calfs.SingleOrDefault(s => s.Id == id);
        }

        public SearchResult<SurveyForSearchDto> GetByChest(int userId, SearchSurveyBindingModels parametes)
        {
            IEnumerable<Chest> chest;

            if (parametes.Query != null)
            {
                chest = _context.Chests.Where(b => ((b.UserId == userId) || (b.TrainerId == userId)) && ((b.UserName.Contains(parametes.Query)))).ToList();
            }
            else
            {
                chest = _context.Chests.Where(u => u.UserId == userId || u.TrainerId == userId).ToList();
            }

            var totalPages = (int)Math.Ceiling((decimal)chest.Count() / parametes.Limit);

            var countList = (int)Math.Ceiling((decimal)chest.Count());

            var property = typeof(Chest).GetProperty(parametes.Sort.FirstCharToUpper());

            if (property == null)
            {
                var defaultParameters = new SearchSurveyBindingModels();
                property = typeof(Chest).GetProperty(defaultParameters.Sort);
            }

            chest = parametes.Ascending
                ? chest.OrderBy(b => property.GetValue(b))
                : chest.OrderByDescending(b => property.GetValue(b));

            chest = chest.Skip(parametes.Limit * (parametes.PageNumber - 1)).Take(parametes.Limit);

            var result = new SearchResult<SurveyForSearchDto>();
            var surveyForSearch = new List<SurveyForSearchDto>();
            chest.ToList().ForEach(b =>
                surveyForSearch.Add(new SurveyForSearchDto
                {
                    Id = b.Id,
                    DateAdded = b.DateAdded,
                    Size = b.Size,
                    TrainerId = b.TrainerId,
                    UserName = b.UserName
                }
            ));

            result.Count = countList;
            result.CurrentPage = parametes.PageNumber;
            result.TotalPageCount = totalPages;
            result.Results = surveyForSearch;

            return result;
        }

        public Chest GetByChestId(int id)
        {
            return _context.Chests.SingleOrDefault(s => s.Id == id);
        }

        public SearchResult<SurveyForSearchDto> GetByHip(int userId, SearchSurveyBindingModels parametes)
        {
            IEnumerable<Hip> hip;

            if (parametes.Query != null)
            {
                hip = _context.Hips.Where(b => ((b.UserId == userId) || (b.TrainerId == userId)) && ((b.UserName.Contains(parametes.Query)))).ToList();
            }
            else
            {
                hip = _context.Hips.Where(u => u.UserId == userId || u.TrainerId == userId).ToList();
            }

            var totalPages = (int)Math.Ceiling((decimal)hip.Count() / parametes.Limit);

            var countList = (int)Math.Ceiling((decimal)hip.Count());

            var property = typeof(Hip).GetProperty(parametes.Sort.FirstCharToUpper());

            if (property == null)
            {
                var defaultParameters = new SearchSurveyBindingModels();
                property = typeof(Hip).GetProperty(defaultParameters.Sort);
            }

            hip = parametes.Ascending
                ? hip.OrderBy(b => property.GetValue(b))
                : hip.OrderByDescending(b => property.GetValue(b));

            hip = hip.Skip(parametes.Limit * (parametes.PageNumber - 1)).Take(parametes.Limit);

            var result = new SearchResult<SurveyForSearchDto>();
            var surveyForSearch = new List<SurveyForSearchDto>();
            hip.ToList().ForEach(b =>
                surveyForSearch.Add(new SurveyForSearchDto
                {
                    Id = b.Id,
                    DateAdded = b.DateAdded,
                    Size = b.Size,
                    TrainerId = b.TrainerId,
                    UserName = b.UserName
                }
            ));

            result.Count = countList;
            result.CurrentPage = parametes.PageNumber;
            result.TotalPageCount = totalPages;
            result.Results = surveyForSearch;

            return result;
        }

        public Hip GetByHipId(int id)
        {
            return _context.Hips.SingleOrDefault(s => s.Id == id);
        }

        public SearchResult<SurveyForSearchDto> GetByThigh(int userId, SearchSurveyBindingModels parametes)
        {
            IEnumerable<Thigh> thigh;

            if (parametes.Query != null)
            {
                thigh = _context.Thighs.Where(b => ((b.UserId == userId) || (b.TrainerId == userId)) && ((b.UserName.Contains(parametes.Query)))).ToList();
            }
            else
            {
                thigh = _context.Thighs.Where(u => u.UserId == userId || u.TrainerId == userId).ToList();
            }

            var totalPages = (int)Math.Ceiling((decimal)thigh.Count() / parametes.Limit);

            var countList = (int)Math.Ceiling((decimal)thigh.Count());

            var property = typeof(Thigh).GetProperty(parametes.Sort.FirstCharToUpper());

            if (property == null)
            {
                var defaultParameters = new SearchSurveyBindingModels();
                property = typeof(Thigh).GetProperty(defaultParameters.Sort);
            }

            thigh = parametes.Ascending
                ? thigh.OrderBy(b => property.GetValue(b))
                : thigh.OrderByDescending(b => property.GetValue(b));

            thigh = thigh.Skip(parametes.Limit * (parametes.PageNumber - 1)).Take(parametes.Limit);

            var result = new SearchResult<SurveyForSearchDto>();
            var surveyForSearch = new List<SurveyForSearchDto>();
            thigh.ToList().ForEach(b =>
                surveyForSearch.Add(new SurveyForSearchDto
                {
                    Id = b.Id,
                    DateAdded = b.DateAdded,
                    Size = b.Size,
                    TrainerId = b.TrainerId,
                    UserName = b.UserName
                }
            ));

            result.Count = countList;
            result.CurrentPage = parametes.PageNumber;
            result.TotalPageCount = totalPages;
            result.Results = surveyForSearch;

            return result;
        }

        public Thigh GetByThighId(int id)
        {
            return _context.Thighs.SingleOrDefault(s => s.Id == id);
        }

        public Surveyy GetSurvey(int userId)
        {
            return _context.Surveys.FirstOrDefault(x => x.UserId == userId);
        }

        public async Task<Biceps> InsertBiceps(Biceps data)
        {
            var result = await _context.Bicepss.AddAsync(data);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<BodyFat> InsertBodyFat(BodyFat data)
        {
            var result = await _context.BodyFats.AddAsync(data);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<BodyWeight> InsertBodyWeight(BodyWeight data)
        {
            var result = await _context.BodyWeights.AddAsync(data);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Calf> InsertCalf(Calf data)
        {
            var result = await _context.Calfs.AddAsync(data);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Chest> InsertChest(Chest data)
        {
            var result = await _context.Chests.AddAsync(data);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Hip> InsertHip(Hip data)
        {
            var result = await _context.Hips.AddAsync(data);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Surveyy> InsertSurvey(Surveyy survey)
        {
            var result = await _context.Surveys.AddAsync(survey);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Thigh> InsertThigh(Thigh data)
        {
            var result = await _context.Thighs.AddAsync(data);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}
