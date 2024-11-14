using HCMS.Domain.Enum;
using MediatR;

namespace HCMS.Application.Features.Jobs.JobTitles
{
    public class AddJobTitleCommand:IRequest<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public JobCatagoryEnum JobCatagoryId { get; set; }
        public JobGradeEnum JobGradeId { get; set; }
    }
}
