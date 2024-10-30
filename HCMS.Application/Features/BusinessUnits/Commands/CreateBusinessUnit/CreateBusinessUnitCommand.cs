using HCMS.Domain.BusinessUnit;
using HCMS.Services.DataService;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HCMS.Application.Features.BusinessUnits.Commands.CreateBusinessUnit
{
    public record CreateBusinessUnitCommand(string BusinessUnitID, string BusinessUnitName, int ParentId, int businessUnitTypeId) : IRequest<int>;

    public class CreateBusinessUnitCommandHandler : IRequestHandler<CreateBusinessUnitCommand, int>
    {
        private readonly IDataService dataService;

        public CreateBusinessUnitCommandHandler(IDataService dataService) => this.dataService = dataService;

        public async Task<int> Handle(CreateBusinessUnitCommand request, CancellationToken cancellationToken)
        {

            var businessUnitList = await dataService.BusinessUnits.ToListAsync();

            var parentBuisnessUnit = businessUnitList.Where(bu => bu.Id == request.ParentId).FirstOrDefault();
            var gParentBusinessUnit = businessUnitList.Where(bu => bu.Id == parentBuisnessUnit.ParentId).FirstOrDefault();


            var businessUnit = new BusinessUnit()
            {
                BusinessUnitID = string.Concat(
                        new string(gParentBusinessUnit.BusinessUnitName.Take(5).ToArray()), "/",
                        new string(parentBuisnessUnit.BusinessUnitName.Take(5).ToArray()), "/",   
                        new string(request.BusinessUnitName.Take(5).ToArray())   
                    ),
                BusinessUnitName = request.BusinessUnitName,
                ParentId = request.ParentId,
                BusinessUnitType=request.businessUnitTypeId
            };

            dataService.BusinessUnits.Add(businessUnit);
            await dataService.SaveAsync(cancellationToken);
            return businessUnit.Id;
        }

    }
}