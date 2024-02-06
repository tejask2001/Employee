using FirstAPI.Interfaces;
using FirstAPI.Models;
using FirstAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentAdminService _adminService;
        private readonly IDepartmentUserService _userService;
        public DepartmentController(IDepartmentAdminService adminService, IDepartmentUserService userService)
        {
            _adminService = adminService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<List<Department>> GetDepartment()
        {
            var department = await _adminService.GetDepartmentListAsync();
            return department;
        }

        [Route("/GetById")]
        [HttpGet]
        public async Task<Department> GetDepartment(int id)
        {
            var department = await _userService.GetDepartment(id);
            return department;
        }
        

        [HttpPost]
        public async Task<Department> PostDepartment(Department department)
        {
            department=await _adminService.AddDepartment(department);
            return department;
        }
    }
}
