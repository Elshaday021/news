using HCMS.Domain.Enum;
using HCMS.Services.DataService;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HCMS.Application.Features.BusinessUnits.Queries
{
    public record BusinessUnitLists(
        List<BusinessUnitDto> Approved,
        List<BusinessUnitDto> Submitted,
        List<BusinessUnitDto> Rejected,
        List<BusinessUnitDto> Draft
        );
    public record GetBusinessUnitsQuery:IRequest<BusinessUnitLists>;
   public class GetBusinessUnitQueryHandler:IRequestHandler<GetBusinessUnitsQuery, BusinessUnitLists>
    {
        private readonly IDataService dataService;
        public GetBusinessUnitQueryHandler(IDataService dataService)
        {
            this.dataService = dataService;
        }
        public async Task<BusinessUnitLists> Handle (GetBusinessUnitsQuery query ,CancellationToken cancellationToken)
        {
            var businessUnitList= await dataService.BusinessUnits.ToListAsync(cancellationToken);
            var businessUnitType= await dataService.BusinessUnitTypes.ToListAsync(cancellationToken);

            var newBusinessUnitList = new List<BusinessUnitDto>();
            foreach (var bu in businessUnitList) {
                var parentBusinessUnit= businessUnitList.Where(b=>b.Id==bu.ParentId).FirstOrDefault();
                var businessUnitTypeInfo = businessUnitType.Where(b => (b.Value) == bu.Type).FirstOrDefault();
                var businessUnit = new BusinessUnitDto()
                {  
                    Id = bu.Id,
                    Name = bu.Name,
                    BusinessUnitID = bu.BusinessUnitID,
                    ParentBusinessUnitName = parentBusinessUnit.Name,
                    ParentId=bu.ParentId,
                    BusinessUnitTypeName = businessUnitTypeInfo.Name,
                    Type=bu.Type,
                    AreaCode= bu.AreaCode,
                    Address=bu.Address,
                    StaffStrength=bu.StaffStrength,
                    ApprovalStatus=bu.ApprovalStatus,

                };
                newBusinessUnitList.Add(businessUnit);
            }
            var approved=newBusinessUnitList.Where(bu=>bu.ApprovalStatus==ApprovalStatus.Approved).ToList();
            var submitted = newBusinessUnitList.Where(bu => bu.ApprovalStatus == ApprovalStatus.Submitted).ToList();
            var rejected= newBusinessUnitList.Where(bu=>bu.ApprovalStatus== ApprovalStatus.Rejected).ToList();   
            var draft=newBusinessUnitList.Where(bu=>bu.ApprovalStatus== ApprovalStatus.Draft).ToList();

            return new BusinessUnitLists(
                Approved:approved,
                Rejected:rejected,
                Submitted:submitted,
                Draft:draft
                ); 
        }
    }
}
