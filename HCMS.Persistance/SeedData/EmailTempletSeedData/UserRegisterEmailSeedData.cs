using HCMS.Domain.EmailTemplet;
using HCMS.Domain.Enum;
using Microsoft.EntityFrameworkCore;

namespace HCMS.DBPersistance.SeedData.EmailTempletSeedData
{
    public class UserRegisterEmailSeedData
    {
        public static void seedUserRegisterEmails(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmailTemplet>()
       .HasKey(e => e.Id);
            modelBuilder.Entity<EmailTemplet>().HasData
               (
                new EmailTemplet()
                {
                    Id = Guid.NewGuid(),
                    EmailRegisterEnum = EmailTypeEnum.UserAccountRegisterNotificationEnum,
                    EmailMessage = $"<br>Dear <strong>{{userRegister.UserName}}</strong>,<br><br>\r\nHumn Capital Management System User has been created!<br>\r\nUserName: <strong>{{userRegister.UserEmail}} </strong><br>\r\nPassword: <strong>{{userRegister.Password}} </strong><br><br>\r\nNote: This is a trial email testing for the Human Capital Management System!\r\n"
                }
                );
        }

    }
}
