using FirstAPI.Interfaces;
using FirstAPI.Mappers;
using FirstAPI.Models.DTOs;
using FirstAPI.Models;
using FirstAPI.Exceptions;
using System.Security.Cryptography;
using System.Text;

namespace FirstAPI.Services
{
    public class UserService:IUserService
    {
        private readonly IRepository<int, Employee> _employeeRepository;
        private readonly IRepository<string, User> _userRepository;
        private readonly ITokenService _tokenService;
        private readonly ILogger<UserService> _logger;

        public UserService(IRepository<int, Employee> employeeRepository,
                            IRepository<string, User> userRepository,
                            ITokenService tokenService,
        ILogger<UserService> logger)
        {
            _employeeRepository = employeeRepository;
            _userRepository = userRepository;
            _logger = logger;
            _tokenService = tokenService;

        }

        public async Task<LoginDTO> Login(LoginDTO user)
        {
            var myUSer = await _userRepository.GetAsync(user.Username);
            if (myUSer == null)
            {
                throw new InvalidUserException();
            }
            var userPassword = GetPasswordEncrypted(user.Password, myUSer.Key);
            var checkPasswordMatch = ComparePasswords(myUSer.Password, userPassword);
            if (checkPasswordMatch)
            {
                user.Password = "";
                user.Role = myUSer.Role;
                user.Token = await _tokenService.GenerateToken(user);
                return user;
            }
            throw new InvalidUserException();
        }

        private bool ComparePasswords(byte[] password, byte[] userPassword)
        {
            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] != userPassword[i])
                    return false;
            }
            return true;
        }

        private byte[] GetPasswordEncrypted(string password, byte[] key)
        {
            HMACSHA256 hmac = new HMACSHA256(key);
            var userpassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return userpassword;
        }

        public async Task<LoginDTO> Register(RegisterUserDTO user)
        {
            User myuser = new RegisterToUser(user).GetUser();
            myuser = await _userRepository.Add(myuser);
            Employee employee = new RegisterToEmployee(user).GetEmployee();
            employee = await _employeeRepository.Add(employee);
            LoginDTO result = new LoginDTO
            {
                Username = myuser.Username,
                Role = myuser.Role,
            };
            return result;

        }
    }
}
