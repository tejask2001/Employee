using FirstAPI.Models;

namespace FirstAPI.Interfaces
{
    public interface IEmployeeUserService
    {
        public Task<Employee> GetEmployee(int id);
    }
}
