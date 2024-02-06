using FirstAPI.Models;

namespace FirstAPI.Interfaces
{
    public interface IDepartmentAdminService
    {
        public Task<List<Department>> GetDepartmentListAsync();
        public Task<Department> AddDepartment(Department department);
        public Task<Department> ChangeDepartmentName(int id,string departmentName);
    }
}