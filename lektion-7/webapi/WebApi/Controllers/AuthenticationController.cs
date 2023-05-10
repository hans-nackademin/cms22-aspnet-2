using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers.Services;
using WebApi.Models.Schemas;

namespace WebApi.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager _userManager;

        public AuthenticationController(UserManager userManager)
        {
            _userManager = userManager;
        }




        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterSchema schema)
        {
            if(ModelState.IsValid)
            {
                if (await _userManager.CheckUserExistsAsync(x => x.Email == schema.Email))
                    return Conflict();

                if (await _userManager.CreateAsync(schema, schema.Password))
                    return Created("", null);
            }
            return BadRequest();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginSchema schema)
        {
            if (ModelState.IsValid)
            {
                if (await _userManager.CheckUserExistsAsync(x => x.Email == schema.Email))
                {
                    var result = await _userManager.LoginAsync(schema.Email, schema.Password);
                    if (result != null)
                        return Ok(result);
                }

                return Unauthorized("Incorrect email or password");
            }

            return Unauthorized("Incorrect email or password");
        }

    }
}
