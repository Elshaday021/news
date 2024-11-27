using HCMS.Application.Features.BusinessUnits;
using HCMS.Application.Features.BusinessUnits.Queries;
using HCMS.Application.Features.Jobs.JobTitles;
using HCMS.Domain;

namespace HCMS.API.Dto
{
    public class LookupDto
    {
        public List<JobTitleDto> JobTitles { get; set; }
        public List<JobCatagory> JobCatagories { get; set;}
        public List<JobGrade> JobGrades { get; set;}
        public BusinessUnitLists BusinessUnits { get; set; }
        public List<BusinessUnitType>  BusinessUnitTypes { get; set; }
    }
}
