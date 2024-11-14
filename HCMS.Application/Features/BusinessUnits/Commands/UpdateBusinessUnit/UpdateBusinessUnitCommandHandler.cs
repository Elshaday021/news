using HCMS.Services.DataService;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Features.BusinessUnits.Commands.UpdateBusinessUnit
{
    public class UpdateBusinessUnitCommandHandler:IRequestHandler<UpdateBusinessUnitCommand,int>
    {
        private readonly IDataService dataService;

        public UpdateBusinessUnitCommandHandler(IDataService dataService)
        {
            this.dataService = dataService; 
        }
        public async Task<int> Handle (UpdateBusinessUnitCommand command,CancellationToken cancellationtoken)
        {
            var businessUnit= dataService.BusinessUnits.Where(bu=>bu.Id==command.Id).FirstOrDefault();
            if (businessUnit == null)
                throw new Exception("unable to find business unit" );
            businessUnit.Name = command.BusinessUnitName;
            businessUnit.Address = command.Address;
            businessUnit.ParentId = command.ParentId;
            businessUnit.AreaCode= command.AreaCode;
            businessUnit.Type = command.businessUnitTypeId;
            businessUnit.StaffStrength= command.StaffStrength;

            await dataService.SaveAsync(cancellationtoken);

            return businessUnit.Id;

        }
    }
}
