using Engineer.Models.BindingModel;
using Engineer.Models.Dto;
using Engineer.Models.Dto.Diet;
using Engineer.Models.Models.Diets;
using Engineer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engineer.Repositories.Repositories
{
    public class DietRepository : IDietRepository
    {
        private readonly DataContext _context;

        public DietRepository(DataContext context)
        {
            _context = context;
        }

        public async Task DeleteAsyncDay(DietDay dietDay)
        {
            _context.DietDays.Remove(dietDay);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsyncDiet(DietPlan dietPlan)
        {
            _context.DietPlans.Remove(dietPlan);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsyncDay(DietDay dietDay)
        {
            _context.DietDays.Update(dietDay);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsyncDetail(DietDetail dietDetail)
        {
            _context.DietDetails.Update(dietDetail);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsyncDiet(DietPlan dietPlan)
        {
            _context.DietPlans.Update(dietPlan);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsyncProduct(DietProduct dietProduct)
        {
            _context.DietProducts.Update(dietProduct);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<DietPlan> GetAllDiets()
        {
            return _context.DietPlans
                .Include(x => x.DietDays)
                    .ThenInclude(y => y.DietDetails)
                        .ThenInclude(z => z.DietProducts);
        }

        public IEnumerable<DietPlan> GetAllUserDiets(int id)
        {
            return _context.DietPlans
                .Include(x => x.DietDays)
                    .ThenInclude(y => y.DietDetails)
                        .ThenInclude(z => z.DietProducts)
                .Where(x => x.Id == id);
        }

        public SearchResult<DietForSearchDto> GetByParameters(int userId, SearchBindingModel parametes)
        {
            IEnumerable<DietPlan> diets;

            if (parametes.Query != null)
            {
                diets = _context.DietPlans.Where(b => ((b.UserDietId == userId) || (b.TrainerDietId == userId)) && ((b.Name.Contains(parametes.Query) || b.UserName.Contains(parametes.Query)))).ToList();
            }
            else
            {
                diets = _context.DietPlans.Where(u => u.UserDietId == userId || u.TrainerDietId == userId).ToList();
            }

            var totalPages = (int)Math.Ceiling((decimal)diets.Count() / parametes.Limit);

            var countList = (int)Math.Ceiling((decimal)diets.Count());

            var property = typeof(DietPlan).GetProperty(parametes.Sort.FirstCharToUpper());

            if (property == null)
            {
                var defaultParameters = new SearchBindingModel();
                property = typeof(DietPlan).GetProperty(defaultParameters.Sort);
            }

            diets = parametes.Ascending
                ? diets.OrderBy(b => property.GetValue(b))
                : diets.OrderByDescending(b => property.GetValue(b));

            diets = diets.Skip(parametes.Limit * (parametes.PageNumber - 1)).Take(parametes.Limit);

            var result = new SearchResult<DietForSearchDto>();
            var trainingsForSearch = new List<DietForSearchDto>();
            diets.ToList().ForEach(b =>
                trainingsForSearch.Add(new DietForSearchDto
                {
                    Id = b.Id,
                    DateStart = b.DateStart,
                    DateEnd = b.DateEnd,
                    Name = b.Name,
                    TrainerName = b.TrainerName,
                    UserName = b.UserName
                }
            ));

            result.Count = countList;
            result.CurrentPage = parametes.PageNumber;
            result.TotalPageCount = totalPages;
            result.Results = trainingsForSearch;

            return result;
        }

        public DietDay GetDayById(int id)
        {
            return _context.DietDays.SingleOrDefault(x => x.Id == id);
        }

        public DietDetail GetDetailById(int id)
        {
            return _context.DietDetails.SingleOrDefault(x => x.Id == id);
        }

        public DietPlan GetDietById(int id)
        {
            return _context.DietPlans
                .Include(x => x.DietDays)
                    .ThenInclude(y => y.DietDetails)
                        .ThenInclude(z => z.DietProducts)
                .SingleOrDefault(x => x.Id == id);
        }

        public DietProduct GetProductById(int id)
        {
            return _context.DietProducts.SingleOrDefault(x => x.Id == id);
        }

        public async Task<DietDay> InserAsyncDay(DietDay dietDay)
        {
            var result = await _context.DietDays.AddAsync(dietDay);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<DietPlan> InsertAsync(DietPlan dietPlan)
        {
            var result = await _context.DietPlans.AddAsync(dietPlan);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<DietDetail> InsertAsyncDetail(DietDetail dietDetail)
        {
            var result = await _context.DietDetails.AddAsync(dietDetail);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<DietProduct> InsertAsyncProduct(DietProduct dietProduct)
        {
            var result = await _context.DietProducts.AddAsync(dietProduct);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}
