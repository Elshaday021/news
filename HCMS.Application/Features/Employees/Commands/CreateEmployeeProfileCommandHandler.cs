using AutoMapper;
using Fluid.Values;
using HCMS.Application.Features.Employees;
using HCMS.Domain;
using HCMS.Services.DataService;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace HCMS.Application.Features.Employees.Commands
{
    public class CreateEmployeeProfileCommandHandler:IRequestHandler <CreateEmployeeProfileCommand,int>
    {
        private readonly IMapper mapper;
        private readonly IDataService dataService;
        public CreateEmployeeProfileCommandHandler(IMapper mapper,IDataService dataService)
        { 
           this.mapper=mapper;
           this.dataService=dataService;
        }
        public async Task<int> Handle (CreateEmployeeProfileCommand request ,CancellationToken cancellationToken)
        {
            var employee=mapper.Map<Employee>(request);

            var vacantJob = dataService.Jobs
                      .Where(jb => jb.Id == employee.JobId)
                      .ExecuteUpdate(jb => jb.SetProperty(job => job.IsVacant, false));

           dataService.Employees.Add(employee);

           await dataService.SaveAsync(cancellationToken);
            return employee.Id;
        }
    }
}
