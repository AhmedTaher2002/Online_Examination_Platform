namespace ExaminationSystem.DTOs.Course
{
    public class GetByIdCourseDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Hours { get; set; }
        public DTOs.Instructor.GetInstructorInfoDTO Instructor { get; set; }
    }
}
