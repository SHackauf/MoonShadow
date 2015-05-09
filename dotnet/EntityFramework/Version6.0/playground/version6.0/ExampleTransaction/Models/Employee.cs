using System.ComponentModel.DataAnnotations.Schema;

namespace ExampleTransaction.Models
{
    class Employee
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
    }
}
