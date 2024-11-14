using HCMS.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace HCMS.Persistance.Configuration
{
    public class BusinessUnitTypeConfiguration:IEntityTypeConfiguration<BusinessUnitType>
    {
        public void Configure (EntityTypeBuilder<BusinessUnitType> builder)
        {
            builder.HasKey(x => x.Value);
            builder.Property(x => x.Name).HasConversion<string>();
            builder.Property(x => x.Value).HasConversion<int>();
        }
    }
}
