using ExaminationSystem.DTOs.Auth;
using ExaminationSystem.Helper;
using ExaminationSystem.Models.Enums;
using ExaminationSystem.Repositories;
using ExaminationSystem.ViewModels.Response;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystem.Services
{
    public class AuthenticationService
    {
        private readonly StudentRepository _studentRepository;
        private readonly InstructorRepository _instructorRepository;

        public AuthenticationService()
        {
            _studentRepository = new StudentRepository();
            _instructorRepository = new InstructorRepository();
        }

        // Login (Email OR Username)
        public async Task<ResponseViewModel<string>> Login(LoginDTO dto)
        {
            var user = await _studentRepository
                .Get(s =>
                    (s.Email == dto.EmailOrUsername || s.Username == dto.EmailOrUsername) &&
                    !s.IsDeleted
                )
                .FirstOrDefaultAsync();

            if (user == null || user.PasswordHash != dto.Password)
                return new FailResponseViewModel<string>("Invalid username/email or password", ErrorCode.InvalidStudentEmail);

            var token = GenerateToken.Generate(user.ID.ToString(), user.FullName, user.Role.ToString());

            return new SuccessResponseViewModel<string>(token);
        }
    }
}
