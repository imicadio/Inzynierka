using Engineer.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Engineer.Repositories.Interfaces
{
    public interface IDatingRepository
    {
        void add<T>(T entity) where T : class;
        void delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
        Task<Photo> GetPhoto(int id);
        User GetByUserId(int id);
        Pupil VerifyPupilTrainer(int trainerId, int pupilId);
    }
}
