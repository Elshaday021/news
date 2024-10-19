using HCMS.Domain.BusinessUnit;
using HCMS.Services.DataService;
using MediatR;

namespace HCMS.Application.Features.BusinessUnits.Commands.CreateBusinessUnit
{
    public record CreateBusinessUnitCommand(string BusinessUnitID, string BusinessUnitName, int ParentId) : IRequest<int>;

    public class CreateBusinessUnitCommandHandler : IRequestHandler<CreateBusinessUnitCommand, int>
    {
        private readonly IDataService dataService;

        public CreateBusinessUnitCommandHandler(IDataService dataService) => this.dataService = dataService;

        public async Task<int> Handle(CreateBusinessUnitCommand request, CancellationToken cancellationToken)
        {
            var businessUnit = new BusinessUnit()
            {
                BusinessUnitID = request.BusinessUnitID,
                BusinessUnitName = request.BusinessUnitName,
                ParentId = request.ParentId,
            };

            dataService.BusinessUnits.Add(businessUnit);
            await dataService.SaveAsync(cancellationToken);
            return businessUnit.Id;
        }

    }
}