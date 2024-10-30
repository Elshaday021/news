using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Features.Jobs.JobCatagories
{
    public class AddJobCatagoryCommand:IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
