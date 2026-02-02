using AutoMapper;
using ExaminationSystem.DTOs.Auth;
using ExaminationSystem.Services;
using ExaminationSystem.ViewModels.Response;
using ExaminationSystem.ViewModels.User;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly AuthenticationService _authenticationService;
        private readonly IMapper _mapper;

        public AuthenticationController(IMapper mapper)
        {
            _authenticationService = new AuthenticationService();
            _mapper = mapper;
        }

        // Student login using Email or Username
        [HttpPost("login")]
        public async Task<ResponseViewModel<string>> StudentLogin( LoginViewModel vm)
        {
            return await _authenticationService.Login(_mapper.Map<LoginDTO>(vm));
        }

    }
}
