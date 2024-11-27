using HCMS.Domain;
using HCMS.Domain.Enum;
using HCMS.Persistance.DBContext;

namespace HCMS.Persistance.SeedData
{
    public class BusinessUnitSeedData
    {
        public static async Task SeedAsync(HCMSDBContext context)
        {
            if (context.BusinessUnits.Any()) return;
            var businessUnits = new List<BusinessUnit>()
            {
                new BusinessUnit() { Name="BerhanBank"  ,BusinessUnitID="Bank" ,BusinessUnitCode="01",ParentId=1, Type=BusinessUnitTypeEnum.Bank,AreaCode="001",Address="Addis Ababa Bole",ApprovalStatus=ApprovalStatus.Approved },

            };
            await context.BusinessUnits.AddRangeAsync(businessUnits);
        }
    }
}
