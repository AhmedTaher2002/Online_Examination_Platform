using ExaminationSystem.Models.Enums;

namespace ExaminationSystem.ViewModels.Instructor
{
    public class UpdateInstructorViewModel
    {
        public string Name { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
    }
}
