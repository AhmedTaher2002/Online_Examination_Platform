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
        private readonly InstructorRepository instructorRepository;
        public AuthenticationService()
        {
            _studentRepository = new StudentRepository();
            instructorRepository = new InstructorRepository();
        }

        // Login (Email OR Username)
        public async Task<ResponseViewModel<string>> Login(LoginDTO dto)
        {
            // Try to find student
            //var student = await _studentrepository
            //    .get(s => (s.email == dto.emailorusername || s.username == dto.emailorusername) && !s.isdeleted)
            //    .firstordefaultasync();

            //if (student != null)
            //{
            //    if (student.passwordhash != dto.password)
            //        return new failresponseviewmodel<string>("invalid username/email or password", errorcode.invalidstudentemail);

            //    var token = generatetoken.generate(student.id.tostring(), student.fullname, student.role.tostring());
            //    return new successresponseviewmodel<string>(token);
            //}

            // Try to find instructor
            var instructor = await instructorRepository
                .Get(i => (i.Email == dto.EmailOrUsername || i.Username == dto.EmailOrUsername) && !i.IsDeleted)
                .FirstOrDefaultAsync();

            if (instructor != null)
            {
                if (instructor.PasswordHash != dto.Password)
                    return new FailResponseViewModel<string>("Invalid username/email or password", ErrorCode.InvalidPassword);

                var token = GenerateToken.Generate(instructor.ID.ToString(), instructor.FullName, "Instructor");
                return new SuccessResponseViewModel<string>(token);
            }

            return new FailResponseViewModel<string>("Invalid username/email or password", ErrorCode.InvalidStudentEmail);
        }
    }
}
