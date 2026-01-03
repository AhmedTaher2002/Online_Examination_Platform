using ExaminationSystem.DTOs.Instructor;
using ExaminationSystem.ViewModels.Instructor;
using System.Collections;

namespace ExaminationSystem.DTOs.Course
{
    public class GetAllCoursesDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Hours { get; set; }
        public DTOs.Instructor.GetInstructorInfoDTO Instructor { get; set; }
    }
}
