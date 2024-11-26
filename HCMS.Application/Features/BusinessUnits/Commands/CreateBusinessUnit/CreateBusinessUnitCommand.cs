using HCMS.Domain;
using HCMS.Domain.Enum;
using HCMS.Service.ValueConverterService;
using HCMS.Services.DataService;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HCMS.Application.Features.BusinessUnits.Commands.CreateBusinessUnit
{
    public record CreateBusinessUnitCommand( string BusinessUnitName, int ParentId, BusinessUnitTypeEnum businessUnitTypeId, string AreaCode ,string Address,int? StaffStrength ) : IRequest<int>;

    public class CreateBusinessUnitCommandHandler : IRequestHandler<CreateBusinessUnitCommand, int>
    {
        private readonly IDataService dataService;
        private readonly IValueConvertor valueConvertor;

        public CreateBusinessUnitCommandHandler(IDataService dataService, IValueConvertor valueConvertor)
        {
            this.dataService = dataService;
            this.valueConvertor = valueConvertor;
        }

        public async Task<int> Handle(CreateBusinessUnitCommand request, CancellationToken cancellationToken)
        {
            var businessUnitId = await GenerateBusinessUnitId(request);

            var businessUnit = new BusinessUnit()
            {
                BusinessUnitID = businessUnitId,
                Name = request.BusinessUnitName,
                ParentId = request.ParentId,
                Type=request.businessUnitTypeId,
                AreaCode=request.AreaCode,
                Address=request.Address,
                StaffStrength=request.StaffStrength,
            };

            dataService.BusinessUnits.Add(businessUnit);
            await dataService.SaveAsync(cancellationToken);
            return businessUnit.Id;
        }
        public async Task<string> GenerateBusinessUnitId (CreateBusinessUnitCommand request)
        {

            var businessUnitList = await dataService.BusinessUnits.ToListAsync();
            var parentBuisnessUnit = businessUnitList.Where(bu => bu.Id == request.ParentId).FirstOrDefault();
            var gParentBusinessUnit = businessUnitList.Where(bu => bu.Id == parentBuisnessUnit.ParentId).FirstOrDefault();
            if (request.businessUnitTypeId == BusinessUnitTypeEnum.ChiefOffice)
            {

            }
            var BusinessUnitID = string.Concat(
                        new string(gParentBusinessUnit.Name.Take(5).ToArray()), "-",
                        new string(parentBuisnessUnit.Name.Take(5).ToArray() ?? null), "-",
                        new string(parentBuisnessUnit.Name.Take(5).ToArray() ?? null), "-",
                        new string(request.BusinessUnitName.Take(5).ToArray() ?? null)
                    );
            return "test";
        }
    }
}