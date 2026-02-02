namespace ExaminationSystem.DTOs.Instructor
{
    public class GetAllInstructorsDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }=null!;
        public string Email { get; set; } = null!;
        public string Username { get; set; } = null!;

    }
}
