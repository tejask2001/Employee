using FirstAPI.Interfaces;
using FirstAPI.Models;

namespace FirstAPI.Services
{
    public class DepartmentService : IDepartmentAdminService, IDepartmentUserService
    {
        IRepository<int,Department> _repo;
        public DepartmentService(IRepository<int, Department> repo)
        {
            _repo = repo;
        }
        public async Task<Department> AddDepartment(Department department)
        {
            department=await _repo.Add(department);
            return department;
        }

        public async Task<Department> ChangeDepartmentName(int id,string departmentName)
        {
            var department = await _repo.GetAsync(id);
            if(department != null) 
            {
                department.Name = departmentName;
                department=await _repo.Update(department);
                return department;
            }
            return null;
        }

        public async Task<Department> GetDepartment(int id)
        {
            var department = await _repo.GetAsync(id);
            return department;
        }

        public async Task<List<Department>> GetDepartmentListAsync()
        {
            var departments= await _repo.GetAsync();
            return departments;
        }
    }
}
