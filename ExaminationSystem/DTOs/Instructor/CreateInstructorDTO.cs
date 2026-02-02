namespace ExaminationSystem.DTOs.Instructor
{
    public class CreateInstructorDTO
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
    }
}
