using Microsoft.AspNetCore.Components.Web;

namespace ExaminationSystem.DTOs.Course
{
    public class CreateCourseDTO
    {
       
        public string Name { get; set; }
        public string Description { get; set; }
        public int Hours { get; set; }
        public int InstructorID { get; set; }
      
    }
}
