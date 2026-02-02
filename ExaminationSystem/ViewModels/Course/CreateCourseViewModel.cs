namespace ExaminationSystem.ViewModels.Course
{
    public class CreateCourseViewModel
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Hours { get; set; }
        public int InstructorID { get; set; }
    }
}
