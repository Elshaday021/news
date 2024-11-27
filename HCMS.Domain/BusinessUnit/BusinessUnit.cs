using HCMS.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace HCMS.Domain
{
    public class BusinessUnit
    {
        [Key]
        public int Id { get; set; }
        public string BusinessUnitID { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public BusinessUnitTypeEnum Type { get; set; }
        public string BusinessUnitCode { get; set; }
        public string AreaCode { get; set; }
        public string Address { get; set; }
        public int? StaffStrength { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }= ApprovalStatus.Draft;
        public BusinessUnitType BusinessUnitType { get; set; }

    }
}
