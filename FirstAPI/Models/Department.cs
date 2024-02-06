using System.ComponentModel.DataAnnotations;

namespace FirstAPI.Models
{
    public class Department:IEquatable<Department>
    {
        [Key]
        public int DepartmentNumber { get; set; }
        public string Name { get; set; }

        public ICollection<Employee> Employees { get; set; }

        public Department()
        {
            
        }

        public Department(int departmentNumber, string name)
        {
            DepartmentNumber = departmentNumber;
            Name = name;
        }

        public bool Equals(Department? other)
        {
            var department= other ?? new Department();
            return this.DepartmentNumber.Equals(department.DepartmentNumber);
        }
    }
}
