namespace FirstAPI.Models.DTOs
{
    public class RegisterUserDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string? Pic { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? DepartmentId { get; set; }
    }
}
