using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RisePingAPIs.Services;

namespace RisePingAPIs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : Controller
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendEmail(string toEmail, string subject, string message)
        {
            await _emailService.SendEmailAsync(toEmail, subject, message);
            return Ok(new { Message = "Email sent successfully!" });
        }
    }
}
