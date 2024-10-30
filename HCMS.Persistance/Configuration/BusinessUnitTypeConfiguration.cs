using HCMS.Domain.BusinessUnit;
using HCMS.Domain.Job;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Persistance.Configuration
{
    public class BusinessUnitTypeConfiguration:IEntityTypeConfiguration<BusinessUnitType>
    {
        public void Configure (EntityTypeBuilder<BusinessUnitType> builder)
        {
            builder.HasKey(x => x.Value);
            builder.Property(x => x.Name).HasConversion<string>();
        }
    }
}
