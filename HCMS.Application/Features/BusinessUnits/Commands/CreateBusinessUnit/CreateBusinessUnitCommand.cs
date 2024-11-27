using HCMS.Application.Features.BusinessUnits.Models;
using HCMS.Application.Features.BusinessUnits.Services;
using HCMS.Domain;
using HCMS.Domain.Enum;
using HCMS.Service.ValueConverterService;
using HCMS.Services.DataService;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HCMS.Application.Features.BusinessUnits.Commands.CreateBusinessUnit
{
    public record CreateBusinessUnitCommand( string Name, int ParentId, BusinessUnitTypeEnum Type, string AreaCode ,string Address,int? StaffStrength ) : IRequest<int>;

    public class CreateBusinessUnitCommandHandler : IRequestHandler<CreateBusinessUnitCommand, int>
    {
        private readonly IDataService dataService;
        private readonly IValueConvertor valueConvertor;
        private readonly IGenerateBusinessUnitCodeService generateBusinessUnitCodeService;

        public CreateBusinessUnitCommandHandler(IDataService dataService, IValueConvertor valueConvertor,IGenerateBusinessUnitCodeService generateBusinessUnitCodeService)
        {
            this.dataService = dataService;
            this.valueConvertor = valueConvertor;
            this.generateBusinessUnitCodeService= generateBusinessUnitCodeService;
        }

        public async Task<int> Handle(CreateBusinessUnitCommand request, CancellationToken cancellationToken)
        {
            var businessUnitId = await generateBusinessUnitCodeService.GenerateBusinessUnitCode(request);

            var businessUnit = new BusinessUnit()
            {
                BusinessUnitID = businessUnitId.BusinessUnitId,
                BusinessUnitCode=businessUnitId.BusinessUnitCode,
                Name = request.Name,
                ParentId = request.ParentId,
                Type=request.Type,
                AreaCode=request.AreaCode,
                Address=request.Address,
                StaffStrength=request.StaffStrength,
            };

            dataService.BusinessUnits.Add(businessUnit);
            await dataService.SaveAsync(cancellationToken);
            return businessUnit.Id;
        }

    }
}