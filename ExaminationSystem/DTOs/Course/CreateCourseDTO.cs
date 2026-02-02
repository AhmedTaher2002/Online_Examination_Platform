using Microsoft.AspNetCore.Components.Web;

namespace ExaminationSystem.DTOs.Course
{
    public class CreateCourseDTO
    {
       
        public string Name { get; set; }= null!;
        public string Description { get; set; } = null!;
        public int Hours { get; set; }
        public int InstructorID { get; set; }
      
    }
}
