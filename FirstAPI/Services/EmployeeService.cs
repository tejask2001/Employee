using FirstAPI.Interfaces;
using FirstAPI.Models;

namespace FirstAPI.Services
{
    public class EmployeeService : IEmployeeAdminService,IEmployeeUserService
    {
        private IRepository<int, Employee> _repo;
        public EmployeeService(IRepository<int, Employee> repo)
        {
            _repo = repo;
        }
        public async Task<Employee> AddEmployee(Employee employee)
        {
            employee=await _repo.Add(employee);
            return employee;
        }

        public async Task<Employee> ChangeEmployeeDepartmentAsync(int id, int departmentId)
        {
            var employee= await _repo.GetAsync(id);
            if(employee!=null) 
            {
                employee.DepartmentId = departmentId;
                employee=await _repo.Update(employee);
                return employee;
            }
            return null;
        }

        public async Task<Employee> ChangeEmployeePhoneAsync(int id, string phone)
        {
            var employee = await _repo.GetAsync(id);
            if (employee != null)
            {
                employee.Phone = phone;
                employee = await _repo.Update(employee);
                return employee;
            }
            return null;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            var employee = await _repo.GetAsync(id);
            return employee;
        }

        public async Task<List<Employee>> GetEmployeeListAsync()
        {
            var employees = await _repo.GetAsync();
            return employees;
        }
        
    }
}
