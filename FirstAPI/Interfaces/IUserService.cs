using FirstAPI.Models.DTOs;

namespace FirstAPI.Interfaces
{
    public interface IUserService
    {
        public Task<LoginDTO> Login(LoginDTO user);
        public Task<LoginDTO> Register(RegisterUserDTO user);
    }
}
