using Engineer.Models.Models;
using Engineer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Engineer.Repositories.Repositories
{
    public class DatingRepository : IDatingRepository
    {
        private readonly DataContext _context;

        public DatingRepository(DataContext context)
        {
            _context = context;
        }
        public void add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public async Task<Photo> GetPhoto(int id)
        {
            var photo = await _context.Photos.FirstOrDefaultAsync(p => p.Id == id);

            return photo;
        }

        public void delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users
                .Include(p => p.Photos)
                .Include(p => p.Trainers)
                .FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.Users.Include(p => p.Photos).ToListAsync();

            return users;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public User GetByUserId(int id)
        {
            return _context.Users.SingleOrDefault(x => x.Id == id);
        }

        public Pupil VerifyPupilTrainer(int trainerId, int pupilId)
        {
            return _context.Pupils.FirstOrDefault(x => x.TrainerId == trainerId && x.PupilId == pupilId);
        }

        public async Task<Photo> GetMainPhotoForUser(int userId)
        {
            return await _context.Photos.Where(u => u.UserId == userId).FirstOrDefaultAsync(p => p.IsMain);
        }

        public async Task<User> GetUser_(int id, bool isCurrentUser)
        {
            var query = _context.Users.Include(p => p.Photos).AsQueryable();

            if (isCurrentUser)
                query = query.IgnoreQueryFilters();

            var user = await query.FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }

        public Pupil GetTrainer(int userId)
        {
            return _context.Pupils.SingleOrDefault(x => x.PupilId == userId);
        }
    }
}
