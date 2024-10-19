using HCMS.Domain.EmailTemplet;
using HCMS.Domain.Enum;
using Microsoft.EntityFrameworkCore;

namespace HCMS.DBPersistance.SeedData.EmailTempletSeedData
{
    public class UserLoginEmailSeedData
    {
        public static void seedUserLoginEmails(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmailTemplet>()
       .HasKey(e => e.Id);
            modelBuilder.Entity<EmailTemplet>().HasData
               (
                new EmailTemplet()
                {
                    Id = Guid.NewGuid(),
                    EmailRegisterEnum = EmailTypeEnum.UserLoginNotificationEnum,
                    EmailMessage = $"<br>Dear <strong>{{userRegister.UserName}}</strong>, <br><br>\r\nPlease use the below verification code to complete your sign-in process!<br>\r\nVerification Code: <strong>{{userRegister.UserEmail}} </strong><br><br>\r\nNote: This is a trial email testing for the Human Capital Management System!<br>"
                }
                );
        }

    }
}
