using FirstAPI.Models;

namespace FirstAPI.Interfaces
{
    public interface IDepartmentUserService
    {
        public Task<Department> GetDepartment(int id);
    }
}
