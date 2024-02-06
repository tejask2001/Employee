using FirstAPI.Exceptions;
using FirstAPI.Interfaces;
using FirstAPI.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<LoginDTO> Register(RegisterUserDTO user)
        {
            var result = await _userService.Register(user);
            return result;
        }

        [Route("Login")]
        [HttpPost]
        public async Task<ActionResult<LoginDTO>> Login(LoginDTO user)
        {
            try
            {
                var result = await _userService.Login(user);
                return Ok(result);
            }
            catch (InvalidUserException iuse)
            {
                _logger.LogCritical(iuse.Message);
                return Unauthorized("Invalid username or password");
            }
        }
    }
}
