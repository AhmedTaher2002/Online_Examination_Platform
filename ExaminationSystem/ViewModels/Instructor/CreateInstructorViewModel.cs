using ExaminationSystem.Models.Enums;

namespace ExaminationSystem.ViewModels.Instructor
{
    public class CreateInstructorViewModel
    {
        public string Name { get; set; }=null!;
        public string Email { get; set; }=null!;
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public Role Role { get; set; }= Role.Instructor;
    }
}
