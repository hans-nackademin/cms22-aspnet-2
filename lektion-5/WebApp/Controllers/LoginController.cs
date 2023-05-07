using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Twitter;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models.ViewModels;

namespace WebApp.Controllers;

public class LoginController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(LoginViewModel viewModel)
    {
        return View(viewModel);
    }


    public async Task Facebook() => await HttpContext.ChallengeAsync(FacebookDefaults.AuthenticationScheme, new AuthenticationProperties { RedirectUri = Url.Action("ExternalLogin")});
    public async Task Google() => await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme, new AuthenticationProperties { RedirectUri = Url.Action("ExternalLogin") });
    public async Task Twitter() => await HttpContext.ChallengeAsync(TwitterDefaults.AuthenticationScheme, new AuthenticationProperties { RedirectUri = Url.Action("ExternalLogin") });

    public async Task<IActionResult> ExternalLogin()
    {
        var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        if (result.Succeeded)
        {
            var claims = result.Principal.Identities.FirstOrDefault()?.Claims.Select(claim => new
            {
                claim.Type, 
                claim.Value
            });

            return Json(claims);
        }

        ModelState.AddModelError("", "Unable to login");
        return RedirectToAction("Index");
    }
}
