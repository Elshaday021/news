using MediatR;
using System.ComponentModel.DataAnnotations;

namespace HCMS.Application.Features.Employees
{
    public class CreateEmployeeProfileCommand:IRequest<int>
    {

        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int BusinessUnitID { get; set; }
        public int JobId { get; set; }
    }
}
