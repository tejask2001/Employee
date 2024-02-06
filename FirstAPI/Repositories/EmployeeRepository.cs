using FirstAPI.Context;
using FirstAPI.Exceptions;
using FirstAPI.Interfaces;
using FirstAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Repositories
{
    public class EmployeeRepository : IRepository<int, Employee>
    {
        readonly RequestTrackerContext _context;
        public EmployeeRepository(RequestTrackerContext context)
        {
            _context = context;
        }
        public async Task<Employee> Add(Employee item)
        {
            _context.Add(item);
            _context.SaveChanges();
            return item;
        }

        public async Task<Employee> Delete(int key)
        {
            var employee = await GetAsync(key);
            _context?.Employees.Remove(employee);
            return employee;
        }

        public async Task<Employee> GetAsync(int key)
        {
            var employees = await GetAsync();
            var employee=employees.FirstOrDefault(e=>e.Id==key);
            if (employee!=null)
            {
                return employee;
            }
            throw new NoSuchEmployeeException();
        }

        public async Task<List<Employee>>? GetAsync()
        {
            var employees = _context.Employees.Include(e => e.Department).ToList();
            return employees;
        }

        public async Task<Employee> Update(Employee item)
        {
            var employee= await GetAsync(item.Id);
            _context.Entry<Employee>(item).State= EntityState.Modified;
            //the above statement generates a update query when the save changesi s called for,
            //for all attributes except the primary  key. 
            //Use teh primary key in the where clause of the update query
            _context.SaveChanges();
            return employee;
        }
    }
}
