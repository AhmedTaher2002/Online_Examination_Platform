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
        private readonly UserRepository _userRepository ;
        public AuthenticationService()
        {
            _userRepository= new UserRepository();
        }

        // Login (Email OR Username)
        public async Task<ResponseViewModel<string>> Login(LoginDTO dto)
        {
            var user = await _userRepository
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
