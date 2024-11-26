using HCMS.Domain.Enum;
using HCMS.Domain;
using HCMS.Persistance.DBContext;

namespace HCMS.Persistance.SeedData
{
    public class JobGradeSeedData
    {
        public static async Task SeedAsync(HCMSDBContext context)
        {
            if (context.JobCatagories.Any()) return;
            var jobGrades = new List<JobGrade>()
            {
                new JobGrade() {Value=JobGradeEnum.JobGradeOne ,Name="JobGrade1",Description="Clerical" },
                new JobGrade() {Value=JobGradeEnum.JobGradeTwo ,Name="JobGrade2",Description="Non_Clerical" },
                new JobGrade() {Value=JobGradeEnum.JobGradeThree ,Name="JobGrade3",Description="Professional" },
                new JobGrade() {Value=JobGradeEnum.JobGradeFour ,Name="JobGrade4",Description="Managerial" }
            };
            await context.JobGrades.AddRangeAsync(jobGrades);
        }
    }
}
