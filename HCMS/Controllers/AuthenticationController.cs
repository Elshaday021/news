using HCMS.ApplicationLayer.UserAccount;
using HCMS.Domain.Enum;
using HCMS.Domain.User.Signin;
using HCMS.Domain.User.Signup;
using HCMS.Domain.User.UserNotification;
using HCMS.Service.Models;
using HCMS.Services.DataService;
using HCMS.Services.EmailService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HCMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IExchangeEmail _emailService;
        private readonly IUserAccount _userAccount;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IDataService _dataservice;
        public AuthenticationController(IExchangeEmail emailService, IDataService dataService,
            SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IUserAccount userAccount)
        {
            this._emailService = emailService;
            this._userAccount = userAccount;
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._dataservice = dataService;
        }

        [HttpPost("RegisterUser")]
        public async Task<ActionResult> RegisterUser([FromBody] UserRegister userRegister, string role)
        {

            var userResult = await _userAccount.CreateUser(userRegister, role);
            if (userResult.Status != "Success")
            {
                return StatusCode(StatusCodes.Status403Forbidden,
                    new NotifyResponse { Status = "Error", Message = userResult.Message });
            }
            return Ok(userResult);

        }

        [HttpPost("LoginUser")]
        public async Task<ActionResult<NotifyResponse>> LoginsAsync([FromBody] UserLogin loginDto)
        {
            var userExist = await _userManager.FindByEmailAsync(loginDto.UserEmail);
            if (userExist == null)
            {
                return new NotifyResponse { Status = "Error", Message = "User Exist App" };

            }

            var isPasswordCorrect = await _userManager.CheckPasswordAsync(userExist, loginDto.Password);
            if (isPasswordCorrect)
            {
                await _userManager.UpdateSecurityStampAsync(userExist);
                var token = await this._userManager.GenerateTwoFactorTokenAsync(userExist, "Email");

                var emailTemplet = await _dataservice.EmailTemplet
                    .FirstOrDefaultAsync(a => a.EmailRegisterEnum == EmailTypeEnum.UserLoginNotificationEnum);
                var populatedTemplate = emailTemplet.EmailMessage
                            .Replace("{userRegister.UserName}", userExist.UserName)
                            .Replace("{userRegister.UserEmail} ", token);

                var msg = new MessageDto
                {
                    Email = loginDto.UserEmail,
                    EmailSubject = "Sign in Verification Code",
                    MessageContent = populatedTemplate
                };

                // (new string[] { loginDto.UserEmail }, "Sign in Verification Code", populatedTemplate);

                _emailService.SendEmails(msg);

                return Ok(new NotifyResponse { Status = "Success", Message = "2FA Code Sent" });
            }
            return Unauthorized(new NotifyResponse { Status = "Error", Message = "Invalid email or password." });

        }


        [HttpPost("verification-code")]
        public async Task<ActionResult> VerificationCode([FromBody] VerificationCode VerificationCode)
        {
            if (string.IsNullOrWhiteSpace(VerificationCode?.Code)) return BadRequest();

            var result = await _signInManager.TwoFactorSignInAsync("Email", VerificationCode.Code, false, false);

            if (!result.Succeeded)
            {
                if (result.IsLockedOut)
                {
                    return BadRequest();
                }
                return BadRequest();
            }

            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
            //await SignInAsync(user);
            return Ok();
        }









        //[HttpGet("Email")]
        //public IActionResult TestEmails()
        //{
        //    var msg = new Messages(new string[] { "Tsegaw.Alemayehu@berhanbanksc.com" }, "Test", "This is test mail");
        //    _emailService.sendEmail(msg);
        //    return StatusCode(StatusCodes.Status200OK,
        //   new NotifyResponse { Status = "Success", Message = "Email Sent" });

        //}
    }
}
