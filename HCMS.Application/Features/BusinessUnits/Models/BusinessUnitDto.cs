using HCMS.Domain;
using HCMS.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace HCMS.Application.Features.BusinessUnits
{
    public class BusinessUnitDto
    {
    
        public int Id { get; set; }
        public string BusinessUnitID { get; set; }
        public string Name { get; set; }
        public string? ParentBusinessUnitName { get; set; }
        public int ParentId { get; set; }
        public string BusinessUnitTypeName  { get; set; }
        public BusinessUnitTypeEnum Type { get; set; }
        public string AreaCode { get; set; }
        public string Address {  get; set; }
        public int? StaffStrength { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }

    }
}
