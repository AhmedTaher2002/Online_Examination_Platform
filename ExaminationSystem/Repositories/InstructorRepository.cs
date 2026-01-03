using ExaminationSystem.Data;
using ExaminationSystem.Models;

namespace ExaminationSystem.Repositories
{
    public class InstructorRepository:GeneralRepository<Instructor>
    {
        Context _context;
        public InstructorRepository() 
        { 
            _context = new Context();
        }
    }
}
