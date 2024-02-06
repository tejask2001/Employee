using FirstAPI.Models.DTOs;
using FirstAPI.Models;

namespace FirstAPI.Mappers
{
    public class RegisterToEmployee
    {
        Employee employee;
        public RegisterToEmployee(RegisterUserDTO register)
        {
            employee = new Employee();
            employee.Name = register.Name;
            employee.Email = register.Email;
            employee.Phone = register.Phone;
            employee.DateofBirth = register.DateOfBirth;
            employee.Pic = register.Pic;
            employee.DepartmentId = register.DepartmentId;
            employee.Username = register.Username;
        }
        public Employee GetEmployee()
        {
            return employee;
        }
    }
}
