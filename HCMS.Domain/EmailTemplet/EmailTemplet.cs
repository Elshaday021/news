using HCMS.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace HCMS.Domain.EmailTemplet
{
    public class EmailTemplet
    {
        [Key]
        public Guid Id { get; set; }
        public EmailTypeEnum EmailRegisterEnum { get; set; }
        public string EmailMessage { get; set; }

    }
}
