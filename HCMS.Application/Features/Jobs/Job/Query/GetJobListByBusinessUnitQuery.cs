using HCMS.Application.Features.Jobs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Features.Jobs
{
    public class GetJobListByBusinessUnitQuery:IRequest<List<JobDto>>
    {
        public int BusinessUnitId { get; set; }
    }
}
