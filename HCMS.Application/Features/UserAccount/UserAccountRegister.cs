using HCMS.Domain.User.Signup;
using HCMS.Domain.User.UserNotification;
using HCMS.Service.Models;
using HCMS.Services.DataService;
using HCMS.Services.EmailService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HCMS.ApplicationLayer.UserAccount
{
    public class UserAccountRegister : IUserAccount
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IExchangeEmail _emailService;
        private readonly IDataService _dataservice;
        public UserAccountRegister(UserManager<IdentityUser> userManager
            , RoleManager<IdentityRole> roleManager, IExchangeEmail emailService, IDataService dataService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _emailService = emailService;
            _dataservice = dataService;
        }

        public async Task<NotifyResponse> CreateUser([FromBody] UserRegister userRegister, string role)
        {

            var userExist = await _userManager.FindByEmailAsync(userRegister.UserEmail);
            if (userExist != null)
            {
                return new NotifyResponse { Status = "Error", Message = "User Exist App" };

            }
            IdentityUser user = new()
            {
                Email = userRegister.UserEmail,
                UserName = userRegister.UserName,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            if (await _roleManager.RoleExistsAsync(role))
            {
                var result = await _userManager.CreateAsync(user, userRegister.Password);
                await _userManager.SetTwoFactorEnabledAsync(user, true);
                var emailTemplet = await _dataservice.EmailTemplet
                .FirstOrDefaultAsync(a => a.EmailRegisterEnum == HCMS.Domain.Enum.EmailTypeEnum.UserAccountRegisterNotificationEnum);
                if (!result.Succeeded)
                {
                    // var errors = result.Errors.Select(e => e.Description).ToList();

                    // Return errors as a response
                    // return BadRequest(new { Errors = errors });
                    var errors = string.Join(Environment.NewLine, result.Errors.Select(e => e.Description));

                    return
                      new NotifyResponse { Status = "Error", Message = $"Failed to Create User!{Environment.NewLine}{errors}" };
                }
                await _userManager.AddToRoleAsync(user, role);

                var populatedTemplate = emailTemplet.EmailMessage
                            .Replace("{userRegister.UserName}", userRegister.UserName)
                            .Replace("{userRegister.UserEmail} ", userRegister.UserEmail)
                            .Replace("{userRegister.Password} ", userRegister.Password);

                //var msg = new MessageDto(new string[] { userRegister.UserEmail }, "Human Capital Management System User Crediential", populatedTemplate);
                var msg = new MessageDto
                {
                    Email = userRegister.UserEmail,
                    EmailSubject = "Human Capital Management System User Crediential",
                    To = userRegister.UserName,
                    MessageContent = populatedTemplate.ToString(),
                };

                _emailService.SendEmails(msg);
                return new NotifyResponse { Status = "Success", Message = "Email Sent" };

            }
            return new NotifyResponse { Status = "Error", Message = $"Role {role} Does Not Exist" };

        }

    }
}
