using FirstAPI.Models.DTOs;

namespace FirstAPI.Interfaces
{
    public interface ITokenService
    {
        public Task<string> GenerateToken(LoginDTO user);
    }
}
