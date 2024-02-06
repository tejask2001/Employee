using FirstAPI.Interfaces;
using FirstAPI.Models;
using FirstAPI.Models.DTOs;
using FirstAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        //static List<Employee> employees = new List<Employee> {
        //    new Employee(101,"Ramu","ramu@gmail.com","9876543210","",new DateTime(2000,10,19)),
        //    new Employee(102,"Somu","somu@gmail.com","4321098765","",new DateTime(2001,1,26))
        //};

        
        private readonly IEmployeeAdminService _adminService;
        private readonly IEmployeeUserService _userService;
        public EmployeeController(IEmployeeAdminService adminService, IEmployeeUserService userService)
        {
            _adminService = adminService;
            _userService = userService;
        }

        [HttpGet]
        [Authorize(Roles ="admin")]
        public async Task<List<Employee>> GetEmployees()
        {
            var employees = await _adminService.GetEmployeeListAsync();
            return employees;
        }

        [Route("GetByID")]
        [HttpGet]
        public async Task<Employee> GetEmployee(int id)
        {
            var employee=await _userService.GetEmployee(id);
            return employee;
        }

        [HttpPost]
        public async Task<Employee> PostEmployee(Employee employee)
        {
            employee = await _adminService.AddEmployee(employee);
            return employee;
        }

        [HttpPut]
        public async Task<Employee> UpdateDepartment(EmployeeDepartmentDTO employeeDTO)
        {
            var employee = await _adminService.ChangeEmployeeDepartmentAsync(employeeDTO.Id, employeeDTO.DepartmentId);
            return employee;
        }

        [Route("[Controller]/ChangePhone")]
        [HttpPut]
        public async Task<Employee> UpdatePhone(EmployeePhoneDTO employeeDTO)
        {
            var employee= await _adminService.ChangeEmployeePhoneAsync(employeeDTO.Id,employeeDTO.Phone);
            return employee;
        }
    }
}
