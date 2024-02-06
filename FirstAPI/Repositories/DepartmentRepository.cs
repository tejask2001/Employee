using FirstAPI.Context;
using FirstAPI.Exceptions;
using FirstAPI.Interfaces;
using FirstAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Repositories
{
    public class DepartmentRepository : IRepository<int, Department>
    {
        readonly RequestTrackerContext _context;
        public DepartmentRepository(RequestTrackerContext context)
        {
            _context = context;
        }
        public async Task<Department> Add(Department item)
        {
            _context.Add(item);
            _context.SaveChanges();
            return item;
        }

        public async Task<Department> Delete(int key)
        {
            var department= await GetAsync(key);
            if (department != null)
            {
                _context?.Remove(department);
                return department;
            }
            return null;
        }

        public async Task<Department> GetAsync(int key)
        {
            var departments = await GetAsync();
            var department = departments.FirstOrDefault(e=>e.DepartmentNumber==key);
            if (department != null)
            {
                return department;
            }
            throw new NoSuchDepartmentException();
        }

        public async Task<List<Department>> GetAsync()
        {
            var department =  _context.Departments.ToList();
            return department;
        }

        public async Task<Department> Update(Department item)
        {
            var department=await GetAsync(item.DepartmentNumber);
            _context.Entry<Department>(item).State = EntityState.Modified;
            _context.SaveChanges();
            return item;
        }
    }
}
