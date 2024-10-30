using System.ComponentModel.DataAnnotations;

namespace HCMS.Domain
{
    public class Employee
    {

        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int BusinessUnitID { get; set; }
        public int JobId { get; set; }
    }
}
