namespace ExaminationSystem.DTOs.Course
{
    public class UpdateCourseDTO
    {
        
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Hours { get; set; }
        public int InstructorId { get; set; }
    }
}
