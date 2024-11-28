using AutoMapper;
using AutoMapper.QueryableExtensions;
using HCMS.Application.Features.BusinessUnits;
using HCMS.Domain.Enum;
using HCMS.Services.DataService;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace SMS.Application;


public record BusinessUnitSearchResult(List<BusinessUnitDto> Items, int TotalCount);
public record GetBusinessUnitsListQuery(ApprovalStatus Status, int PageNumber, int PageSize) : IRequest<BusinessUnitSearchResult>;


public class GetBusinessUnitsListQueryHandler : IRequestHandler<GetBusinessUnitsListQuery, BusinessUnitSearchResult>
{
    private readonly IMapper mapper;
    private readonly IDataService dataService;

    public GetBusinessUnitsListQueryHandler(IMapper mapper, IDataService dataService)
    {
        this.mapper = mapper;
        this.dataService = dataService;
    }

    public async Task<BusinessUnitSearchResult> Handle(GetBusinessUnitsListQuery request, CancellationToken cancellationToken)
    {
        var businessUnitList = await dataService.BusinessUnits.ToListAsync(cancellationToken);
        var businessUnitType = await dataService.BusinessUnitTypes.ToListAsync(cancellationToken);

        var newBusinessUnitList = new List<BusinessUnitDto>();
        foreach (var bu in businessUnitList)
        {
            var parentBusinessUnit = businessUnitList.Where(b => b.Id == bu.ParentId).FirstOrDefault();
            var businessUnitTypeInfo = businessUnitType.Where(b => (b.Value) == bu.Type).FirstOrDefault();
            var businessUnit = new BusinessUnitDto()
            {
                Id = bu.Id,
                Name = bu.Name,
                BusinessUnitID = bu.BusinessUnitID,
                ParentBusinessUnitName = parentBusinessUnit.Name,
                ParentId = bu.ParentId,
                BusinessUnitTypeName = businessUnitTypeInfo.Name,
                Type = bu.Type,
                AreaCode = bu.AreaCode,
                Address = bu.Address,
                StaffStrength = bu.StaffStrength,
                ApprovalStatus = bu.ApprovalStatus,

            };
            newBusinessUnitList.Add(businessUnit);
        }
        if (request.Status == ApprovalStatus.Submitted)
        {
            var result = newBusinessUnitList.Where(bu => bu.ApprovalStatus == ApprovalStatus.Submitted).ToList();
           
            var count = await dataService.BusinessUnits.Where(bu=>bu.ApprovalStatus==ApprovalStatus.Submitted).CountAsync();

            return new(result, count);
        }
        else if (request.Status == ApprovalStatus.Rejected)
        {
              var result = newBusinessUnitList.Where(bu => bu.ApprovalStatus == ApprovalStatus.Rejected).ToList();
            var count = await dataService.BusinessUnits.Where(bu => bu.ApprovalStatus == ApprovalStatus.Rejected).CountAsync();


            return new(result, count);
        }
        else if (request.Status == ApprovalStatus.Draft)
        {
          var result = newBusinessUnitList.Where(bu => bu.ApprovalStatus == ApprovalStatus.Draft).ToList();
         var count = await dataService.BusinessUnits.Where(bu => bu.ApprovalStatus == ApprovalStatus.Draft).CountAsync();

            return new(result, count);
        }
        else
        {
            var result = newBusinessUnitList.Where(bu => bu.ApprovalStatus == ApprovalStatus.Approved).ToList();
            var count = await dataService.BusinessUnits.Where(bu => bu.ApprovalStatus == ApprovalStatus.Approved).CountAsync();
            return new(result, count);
        }

        return null;
    }


}
