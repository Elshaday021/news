using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HCMS.Application.Features.Jobs.JobTitles
{
    public class AddJobTitleCommand:IRequest<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int JobCatagoryId { get; set; }
        public int JobGradeId { get; set; }
    }
}
