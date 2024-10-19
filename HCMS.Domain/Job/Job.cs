using System.ComponentModel.DataAnnotations;

namespace HCMS.Domain.Job
{
    public class Job
    {
        [Key]
        public int Id { get; set; }
        public int JobTypeId { get; set; }
        public string JobDescription { get; set; }
        public int EmployeeId { get; set; }
    }
}
