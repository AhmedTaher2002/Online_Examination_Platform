namespace ExaminationSystem.DTOs.Student
{
    public class UpdateStudentDTO
    {
        public int StudentId { get; set; }
        public string Name { get; set; }= null!;
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
    }
}
