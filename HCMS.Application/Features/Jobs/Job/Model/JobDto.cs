using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Features.Jobs
{
    public class JobDto
    {
        public int Id { get; set; }
        public string JobTitle { get; set; }
        public string BusinessUnit { get; set; }
        public int? BusinessUnitId { get; set; }
        public string Vacant { get; set; }
        public bool IsVacant { get; set; }

    }
}
