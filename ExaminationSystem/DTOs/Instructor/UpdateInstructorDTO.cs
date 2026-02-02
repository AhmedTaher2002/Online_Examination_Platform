using ExaminationSystem.Models.Enums;

namespace ExaminationSystem.DTOs.Instructor
{
    public class UpdateInstructorDTO
    {
        public string Name { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
    }
}
