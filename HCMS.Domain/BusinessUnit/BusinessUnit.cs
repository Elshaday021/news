using System.ComponentModel.DataAnnotations;

namespace HCMS.Domain.BusinessUnit
{
    public class BusinessUnit
    {
        [Key]
        public int Id { get; set; }
        public string BusinessUnitID { get; set; }
        public string BusinessUnitName { get; set; }
        public int ParentId { get; set; }

    }
}
