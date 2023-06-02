using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers.Services;
using WebApi.Models.Schemas;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsController : ControllerBase
    {
        private readonly SmsService _sms;

        public SmsController(SmsService sms)
        {
            _sms = sms;
        }

        [HttpPost]
        public async Task<IActionResult> Send(SmsSchema schema)
        {
            var result = await _sms.SendAsync(schema.To, schema.Message);
            if (result != null)
                return Ok(result);

            return BadRequest();
        }
    }
}
