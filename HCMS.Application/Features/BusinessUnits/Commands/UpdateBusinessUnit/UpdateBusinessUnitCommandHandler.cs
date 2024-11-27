using AutoMapper;
using HCMS.Application.Features.BusinessUnits.Commands.CreateBusinessUnit;
using HCMS.Application.Features.BusinessUnits.Services;
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
        private readonly IGenerateBusinessUnitCodeService generateBusinessUnitCodeService;
        private readonly IMapper mapper;

        public UpdateBusinessUnitCommandHandler(IDataService dataService,IGenerateBusinessUnitCodeService generateBusinessUnitCode,IMapper mapper)
        {
            this.dataService = dataService; 
            this.generateBusinessUnitCodeService=generateBusinessUnitCode;
            this.mapper = mapper;
        }
        public async Task<int> Handle (UpdateBusinessUnitCommand command,CancellationToken cancellationtoken)
        {
            var businessUnit= dataService.BusinessUnits.Where(bu=>bu.Id==command.Id).FirstOrDefault();
            if (businessUnit == null)
                throw new Exception("unable to find business unit" );
            businessUnit.Name = command.Name;
            businessUnit.Address = command.Address;
            businessUnit.ParentId = command.ParentId;
            businessUnit.AreaCode= command.AreaCode;
            businessUnit.Type = command.Type;
            businessUnit.StaffStrength= command.StaffStrength;

            //The Below code handle regenration of Business Unit Code and ID of the selected business unit to be updated
            var updateCommand= mapper.Map<CreateBusinessUnitCommand>(command);
            var newBusinessUnitCode = await generateBusinessUnitCodeService.GenerateBusinessUnitCode(updateCommand);
            businessUnit.BusinessUnitCode = newBusinessUnitCode.BusinessUnitCode;
            businessUnit.BusinessUnitID = newBusinessUnitCode.BusinessUnitId;

            await dataService.SaveAsync(cancellationtoken);

            return businessUnit.Id;

        }
    }
}
