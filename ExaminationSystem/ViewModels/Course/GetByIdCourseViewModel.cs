namespace ExaminationSystem.ViewModels.Course
{
    public class GetByIdCourseViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }= null!;
        public string Description { get; set; }= null!;
        public int Hours { get; set; }
        public DTOs.Instructor.GetInstructorInfoDTO Instructor { get; set; }

    }
}
