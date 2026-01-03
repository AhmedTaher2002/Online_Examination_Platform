using ExaminationSystem.Data;
using ExaminationSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ExaminationSystem.Repositories
{
    public class ExamRepository : GeneralRepository<Exam>
    {
        Context _context;
        CourseRepository _courseRepository ;
        public ExamRepository()
        {
            _context = new Context();
            _courseRepository = new CourseRepository();
        }
      

        public async Task<Exam> GetExamWithQuestions(int examID)
        {
            var res = await _context.Exams.Include(e => e.ExamQuestions).ThenInclude(eq => eq.Question).Where(e => e.ID == examID).FirstOrDefaultAsync();
            return res;
        }


    }
}
