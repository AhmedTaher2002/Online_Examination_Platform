using ExaminationSystem.Data;
using ExaminationSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ExaminationSystem.DTOs;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.HttpOverrides;
using ExaminationSystem.DTOs.Course;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.Repositories
{
    public class CourseRepository : GeneralRepository<Course>
    {
        Context _context;
        public CourseRepository()
        {
            _context = new Context();
        }
        public Task<bool> IsExist(string courseName)
        {
            var course = _context.Courses.AnyAsync(c => c.Name == courseName && !c.IsDeleted);
            return course;
        }
        public async Task<Course> GetCourseWithExams(int courseID)
        {
            var res = await _context.Courses.Include(c => c.Exams).Where(c => c.ID == courseID).FirstOrDefaultAsync();
            return res;
        }
     }
}
