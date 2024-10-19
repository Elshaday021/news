using HCMS.DBPersistance.SeedData;
using HCMS.DBPersistance.SeedData.EmailTempletSeedData;
using HCMS.Domain.BusinessUnit;
using HCMS.Domain.EmailTemplet;
using HCMS.Domain.Employee;
using HCMS.Domain.Job;
using HCMS.Domain.JobType;
using HCMS.Services.DataService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HCMS.Persistance.DBContext
{
    public class HCMSDBContext : IdentityDbContext<IdentityUser>, IDataService
    {
        public HCMSDBContext(DbContextOptions<HCMSDBContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            UserRoleSeedData.seedRoles(modelBuilder);
            UserRegisterEmailSeedData.seedUserRegisterEmails(modelBuilder);
            UserLoginEmailSeedData.seedUserLoginEmails(modelBuilder);
        }

        public DbSet<BusinessUnit> BusinessUnits { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<JobType> JobTypes { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<EmailTemplet> EmailTemplet { get; set; }
        public void Save()
        {
            this.SaveChanges();
        }

        public async Task SaveAsync(CancellationToken cancellationToken)
        {
            await SaveChangesAsync(cancellationToken);
        }
    }

}
