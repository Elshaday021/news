using HCMS.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HCMS.Persistance.Configuration
{
    public class JobTitleConfiguration:IEntityTypeConfiguration<JobTitle>
    {
        public void Configure (EntityTypeBuilder<JobTitle> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.JobGrade).WithMany().HasForeignKey(x => x.JobGradeId);
            builder.HasOne(x => x.JobCatagory).WithMany().HasForeignKey(x => x.JobCatagoryId);
 
        }
    }
}
