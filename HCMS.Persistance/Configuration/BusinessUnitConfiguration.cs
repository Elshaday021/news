using HCMS.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace HCMS.Persistance.Configuration
{
    public class BusinessUnitConfiguration : IEntityTypeConfiguration<BusinessUnit>
    {
        public void Configure (EntityTypeBuilder<BusinessUnit> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x=>x.BusinessUnitType).WithMany().HasForeignKey(x => x.Type);
        }
    }
}
