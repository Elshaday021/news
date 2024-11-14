using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Domain
{
    public class Job
    {
        public int Id { get; set; }
        public int JobTitleId { get; set; }
        public int BusinessUnitId { get; set; }
        public bool IsVacant { get; set; }
        public BusinessUnit BusinessUnit { get; set; }
        public JobTitle JobTitle { get; set; }

    }
}
