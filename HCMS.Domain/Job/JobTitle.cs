using HCMS.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Domain
{
    public class JobTitle
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public JobCatagoryEnum JobCatagoryId {  get; set; }
        public JobGradeEnum JobGradeId { get; set; }
        public JobGrade JobGrade { get; set; }
        public JobCatagory JobCatagory { get; set; }
    }
}
