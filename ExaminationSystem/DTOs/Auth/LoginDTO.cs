namespace ExaminationSystem.DTOs.Auth
{
    public class LoginDTO
    {
        public string EmailOrUsername { get; set; }= null!;
        public string Password { get; set; } = null!;
    }
}
