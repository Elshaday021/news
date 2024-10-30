using HCMS.Domain.BusinessUnit;
using HCMS.Domain.Enum;
using HCMS.Domain.Job;
using HCMS.Persistance.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Persistance.SeedData
{
    public class BusinessUnitTypeSeedData
    {
        public static async Task SeedAsync(HCMSDBContext context)
        {
            if (context.BusinessUnitTypes.Any()) return;
            var businessUnitTypes = new List<BusinessUnitType>()
            {
                new BusinessUnitType() {Value=BusinessUnitTypeEnum.District ,Name="District",Description="District" },
                new BusinessUnitType() {Value=BusinessUnitTypeEnum.Branch ,Name="Branch",Description="Branch" },
                new BusinessUnitType() {Value=BusinessUnitTypeEnum.Department ,Name="Department",Description="Department" },
                new BusinessUnitType() {Value=BusinessUnitTypeEnum.Division ,Name="Division",Description="Division" },
                new BusinessUnitType() {Value=BusinessUnitTypeEnum.Section ,Name="Section",Description="Section" }
            };
            await context.BusinessUnitTypes.AddRangeAsync(businessUnitTypes);
        }
    }
}
