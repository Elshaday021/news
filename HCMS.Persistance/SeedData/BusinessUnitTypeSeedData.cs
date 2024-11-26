using HCMS.Domain;
using HCMS.Domain.Enum;
using HCMS.Persistance.DBContext;

namespace HCMS.Persistance.SeedData
{
    public class BusinessUnitTypeSeedData
    {
        public static async Task SeedAsync(HCMSDBContext context)
        {
            if (context.BusinessUnitTypes.Any()) return;
            var businessUnitTypes = new List<BusinessUnitType>()
            {
                new BusinessUnitType() {Value=BusinessUnitTypeEnum.ChiefOffice ,Name="ChiefOffice",Description="ChiefOffice" },
                new BusinessUnitType() {Value=BusinessUnitTypeEnum.DepartmentorDistrict ,Name="DepartmentorDistrict",Description="DepartmentorDistrict" },
                new BusinessUnitType() {Value=BusinessUnitTypeEnum.BranchorDivision ,Name="BranchorDivision",Description="BranchorDivision" },
                new BusinessUnitType() {Value=BusinessUnitTypeEnum.Section ,Name="Section",Description="Section" }
            };
            await context.BusinessUnitTypes.AddRangeAsync(businessUnitTypes);
        }
    }
}
