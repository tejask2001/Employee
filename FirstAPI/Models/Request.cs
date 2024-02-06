using System.ComponentModel.DataAnnotations;

namespace FirstAPI.Models
{
    public class Request
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Request text has to be provided. Please enter your issue")]
        public string RequestText { get; set; }

        public string RequestType { get; set; }

        public string? Status { get; set; } = "Created";

        public DateTime? RaisedDate { get; set; } = DateTime.Today;
        public DateTime? LastUpdatedDte { get; set; }
        public DateTime? ResolvedDate { get; set; }
        public int Issuer_Id { get; set; }
        public int? Resolver_Id { get; set; }

        public Employee? Issuer { get; set; }
        public Employee? Resolver { get; set; }
    }
}
