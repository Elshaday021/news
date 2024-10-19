using System.ComponentModel.DataAnnotations;

namespace HCMS.Domain.Employee
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int BusinessUnitID { get; set; }
        public int JobId { get; set; }
    }
}
