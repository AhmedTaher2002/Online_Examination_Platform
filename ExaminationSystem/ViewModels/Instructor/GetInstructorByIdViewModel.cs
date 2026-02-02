namespace ExaminationSystem.ViewModels.Instructor
{
    public class GetInstructorByIdViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
