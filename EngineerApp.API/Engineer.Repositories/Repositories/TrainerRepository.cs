using Engineer.Models.Models;
using Engineer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engineer.Repositories.Repositories
{
    public class TrainerRepository : ITrainerRepository
    {
        private readonly DataContext _context;

        public TrainerRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAllPupils(int id)
        {
            return _context.Users
                .Include(x => x.PupilsTrainer).Where(x => x.PupilsTrainer.TrainerId == id);
        }

        public async Task<Pupil> InertPupil(Pupil pupils)
        {
            var result = await _context.Pupils.AddAsync(pupils);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<User> InsertUser(User user)
        {
            var result = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}
