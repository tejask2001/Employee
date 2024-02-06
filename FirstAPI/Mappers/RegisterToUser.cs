using FirstAPI.Models.DTOs;
using FirstAPI.Models;
using System.Security.Cryptography;
using System.Text;

namespace FirstAPI.Mappers
{
    public class RegisterToUser
    {
        User user;
        public RegisterToUser(RegisterUserDTO register)
        {
            user = new User();
            user.Username = register.Username;
            user.Role = register.Role;
            GetPassword(register.Password);
        }
        void GetPassword(string password)
        {
            HMACSHA256 hmac = new HMACSHA256();
            user.Key = hmac.Key;
            user.Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
        public User GetUser()
        {
            return user;
        }
    }
}
