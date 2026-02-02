namespace ExaminationSystem.ViewModels.Course
{
    public class UpdateCourseViewModel
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Hours { get; set; }
        public int InstructorId { get; set; }
    }
}
