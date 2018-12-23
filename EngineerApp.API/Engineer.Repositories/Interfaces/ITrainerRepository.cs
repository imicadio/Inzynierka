using Engineer.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Engineer.Repositories.Interfaces
{
    public interface ITrainerRepository
    {
        Task<User> InsertUser(User user);
        Task<Pupil> InertPupil(Pupil pupils);

        IEnumerable<User> GetAllPupils(int id);
    }
}
