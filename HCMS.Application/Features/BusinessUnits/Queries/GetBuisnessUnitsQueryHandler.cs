using HCMS.Services.DataService;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HCMS.Application.Features.BusinessUnits.Queries
{
    public record GetBusinessUnitsQuery:IRequest<List<BusinessUnitDto>>;
   public class GetBusinessUnitQueryHandler:IRequestHandler<GetBusinessUnitsQuery, List<BusinessUnitDto>>
    {
        private readonly IDataService dataService;
        public GetBusinessUnitQueryHandler(IDataService dataService)
        {
            this.dataService = dataService;
        }
        public async Task< List<BusinessUnitDto>> Handle (GetBusinessUnitsQuery query ,CancellationToken cancellationToken)
        {
            var businessUnitList= await dataService.BusinessUnits.ToListAsync(cancellationToken);
            var businessUnitType= await dataService.BusinessUnitTypes.ToListAsync(cancellationToken);

            var newBusinessUnitList = new List<BusinessUnitDto>();
            foreach (var bu in businessUnitList) {
                var parentBusinessUnit= businessUnitList.Where(b=>b.Id==bu.ParentId).FirstOrDefault();
                var businessUnitTypeInfo = businessUnitType.Where(b => ((int)b.Value) == bu.BusinessUnitType).FirstOrDefault();
                var businessUnit = new BusinessUnitDto()
                {  
                    Id = bu.Id,
                    BusinessUnitName = bu.BusinessUnitName,
                    BusinessUnitID = bu.BusinessUnitID,
                    ParentBusinessUnit = parentBusinessUnit.BusinessUnitName,
                    BusinessUnitTypeName = businessUnitTypeInfo.Name

                };
                newBusinessUnitList.Add(businessUnit);
            }
            return newBusinessUnitList;
        }
    }
}
