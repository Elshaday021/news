using HCMS.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HCMS.Persistance.Configuration
{
    public class JobConfiguration:IEntityTypeConfiguration<Job>
    {
        public void Configure (EntityTypeBuilder<Job> builder)
        {
            builder.HasKey(x => x.Id);
          builder.HasOne(x=>x.BusinessUnit).WithMany().HasForeignKey(x => x.BusinessUnitId);
            builder.HasOne(x => x.JobTitle).WithMany().HasForeignKey(x => x.JobTitleId);
        }
    }
}
