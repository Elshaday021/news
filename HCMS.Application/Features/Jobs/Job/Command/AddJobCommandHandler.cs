using HCMS.Domain.Job;
using HCMS.Services.DataService;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Features.Jobs.Command
{
    public record AddJobCommand(int jobTitleID, int businessunitId):IRequest<int>;
    public class AddJobCommandHandler:IRequestHandler<AddJobCommand,int>
    {
        private readonly IDataService dataservice;
        public  AddJobCommandHandler(IDataService dataService)
        {
            this.dataservice= dataService;
        }
        public async Task <int> Handle (AddJobCommand command,CancellationToken cancellationToken)
        {
            var newJob = new Job()
            {
                JobTitleId = command.jobTitleID,
                BusinessUnitId = command.businessunitId,
                IsVacant = true
            };
            await dataservice.Jobs.AddAsync(newJob);
            await dataservice.SaveAsync(cancellationToken);

            return newJob.Id;

        }
    }
}
