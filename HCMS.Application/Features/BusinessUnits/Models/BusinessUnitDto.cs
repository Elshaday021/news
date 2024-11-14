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
        public BusinessUnit ParentBusinessUnit { get; set; }
        public int ParentId { get; set; }
        public string Type { get; set; }
        public BusinessUnitTypeEnum businessUnitTypeId { get; set; }
        public string AreaCode { get; set; }
        public string Address {  get; set; }
        public int? StaffStrength { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }

    }
}
