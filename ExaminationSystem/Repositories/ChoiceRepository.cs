using ExaminationSystem.Data;
using ExaminationSystem.Models;

namespace ExaminationSystem.Repositories
{
    public class ChoiceRepository:GeneralRepository<Choice>
    {
        Context _context;
        public ChoiceRepository()
        {
            _context = new Context();
        }
        
       

    }
}
