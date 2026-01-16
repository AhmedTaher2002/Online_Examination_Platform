using ExaminationSystem.Data;
using ExaminationSystem.Models;

namespace ExaminationSystem.Repositories
{
    public class UserRepository:GeneralRepository<User>
    {
        private readonly Context _context;
        public UserRepository()
        {
            _context = new Context();
        }
    }
}
