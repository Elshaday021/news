using HCMS.Domain.BusinessUnit;
using HCMS.Domain.EmailTemplet;
using HCMS.Domain.Employee;
using HCMS.Domain.Job;
using HCMS.Domain.JobType;
using Microsoft.EntityFrameworkCore;

namespace HCMS.Services.DataService
{
    public interface IDataService
    {
        public DbSet<BusinessUnit> BusinessUnits { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<JobType> JobTypes { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<EmailTemplet> EmailTemplet { get; set; }
        void Save();
        Task SaveAsync(CancellationToken cancellationToken);
    }
}
