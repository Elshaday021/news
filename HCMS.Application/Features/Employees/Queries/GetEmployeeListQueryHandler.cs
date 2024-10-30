using HCMS.Application.Features.Jobs.JobTitles;
using HCMS.Domain;
using HCMS.Domain.BusinessUnit;
using HCMS.Services.DataService;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Features.Employees.Queries
{
    public record GetEmployeeListQuery:IRequest<List<EmployeeDto>>;
   public class GetEmployeeListQueryHandler : IRequestHandler<GetEmployeeListQuery, List<EmployeeDto>>
    {
        private readonly IDataService dataService;
        public GetEmployeeListQueryHandler(IDataService dataService)
        {
            this.dataService = dataService;
        }
        public async Task< List<EmployeeDto>> Handle (GetEmployeeListQuery query ,CancellationToken cancellationToken)
        {
            //return await dataService.Employees.ToListAsync(cancellationToken);
            var employeeList = await dataService.Employees.ToListAsync();
            var newemployeeList = new List<EmployeeDto>();
            var businessUnitList = await dataService.BusinessUnits.ToListAsync();
            var jobTitleList = await dataService.JobTitles.ToListAsync();
            foreach (var emp in employeeList)
            {

                var businessUnit = businessUnitList.Where(bu => bu.Id == emp.BusinessUnitID).FirstOrDefault();
                var jobTitle = jobTitleList.Where(j => j.Id== emp.JobId).FirstOrDefault();

                var employee = new EmployeeDto()
                {
                    EmployeeName = emp.EmployeeName,
                    EmployeeId = emp.EmployeeId,
                    BusinessUnit = businessUnit.BusinessUnitName,
                    JobTitle = jobTitle.Title,
                };
                newemployeeList.Add(employee);
            }
            return newemployeeList;
        }
    }
}
