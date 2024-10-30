using System.ComponentModel.DataAnnotations;

namespace HCMS.Domain
{
    public class EmployeeDto
    {

        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string BusinessUnit { get; set; }
        public string JobTitle { get; set; }
    }
}
