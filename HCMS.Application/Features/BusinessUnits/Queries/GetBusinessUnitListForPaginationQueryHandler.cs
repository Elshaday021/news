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
        if (request.Status == ApprovalStatus.Submitted)
        {
            var result = await dataService.BusinessUnits
                .OrderBy(s => s.Id)
                .Where(bu=>bu.ApprovalStatus==ApprovalStatus.Submitted)
                       .ProjectTo<BusinessUnitDto>(mapper.ConfigurationProvider)
                .Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize)
                .AsNoTracking().ToListAsync();

            var count = await dataService.BusinessUnits.Where(bu=>bu.ApprovalStatus==ApprovalStatus.Submitted).CountAsync();

            return new(result, count);
        }
        else if (request.Status == ApprovalStatus.Rejected)
        {
            var result = await dataService.BusinessUnits
                .OrderBy(s => s.Id)
                 .Where(bu => bu.ApprovalStatus == ApprovalStatus.Rejected)
                .Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize)
                 .ProjectTo<BusinessUnitDto>(mapper.ConfigurationProvider)
                .AsNoTracking().ToListAsync();

            var count = await dataService.BusinessUnits.Where(bu => bu.ApprovalStatus == ApprovalStatus.Rejected).CountAsync();


            return new(result, count);
        }
        else if (request.Status == ApprovalStatus.Draft)
        {
            var result = await dataService.BusinessUnits
                .OrderBy(s => s.Id)
                    .Where(bu => bu.ApprovalStatus == ApprovalStatus.Draft)
                .Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize)
                .ProjectTo<BusinessUnitDto>(mapper.ConfigurationProvider)
                .AsNoTracking().ToListAsync();

            var count = await dataService.BusinessUnits.Where(bu => bu.ApprovalStatus == ApprovalStatus.Draft).CountAsync();


            return new(result, count);
        }
        else
        {
            var result = await dataService.BusinessUnits
                .OrderBy(s => s.Id)
                .Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize)
                    .ProjectTo<BusinessUnitDto>(mapper.ConfigurationProvider)
                .AsNoTracking().ToListAsync();

            var count = await dataService.BusinessUnits.Where(bu => bu.ApprovalStatus == ApprovalStatus.Submitted).CountAsync();
            return new(result, count);
        }

        return null;
    }


}
