using System.ComponentModel.DataAnnotations.Schema;

namespace FirstAPI.Models
{
    public class Employee:IEquatable<Employee>
    {
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string? Pic { get; set; }
        public DateTime DateofBirth { get; set; }
        public string Username { get; set; }
        public int? DepartmentId { get; set; }
        //This one is just for navigation and will not be created as an attribute in table
        [ForeignKey("DepartmentId")]
        public Department? Department { get; set;}

        [ForeignKey("Username")]
        public User User { get; set; }

        public ICollection<Request>? RaisedRequests { get; set; }
        public ICollection<Request>? ResolvedRequests { get; set; }

        public Employee()
        {
            
        }

        public Employee(int id, string name, string email, string phone, string? pic, DateTime dateofBirth)
        {
            Id = id;
            Name = name;
            Email = email;
            Phone = phone;
            Pic = pic;
            DateofBirth = dateofBirth;
        }

        public bool Equals(Employee? other)
        {
            var employee = other ?? new Employee();
            return this.Id.Equals(employee.Id);
        }
    }
}
