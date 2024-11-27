using HCMS.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Domain
{
    public class JobGrade
    {
        public JobGradeEnum Value { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
