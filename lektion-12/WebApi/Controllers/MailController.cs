using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers.Services;
using WebApi.Models.Schemas;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly MailerService _mailer;

        public MailController(MailerService mailer)
        {
            _mailer = mailer;
        }

        [HttpPost]
        public async Task<IActionResult> Send(MailSchema schema)
        {
            var result = await _mailer.SendAsync(schema.To, schema.Subject, schema.Message);
            if (!string.IsNullOrEmpty(result))
                return Ok(result);

            return BadRequest();
        }
    }
}
