using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(x =>
{
    x.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
})
.AddCookie()
.AddFacebook(x =>
{
    x.ClientId = builder.Configuration["Facebook:ClientId"]!;
    x.ClientSecret = builder.Configuration["Facebook:ClientSecret"]!;
})
.AddGoogle(x =>
{
    x.ClientId = builder.Configuration["Google:ClientId"]!;
    x.ClientSecret = builder.Configuration["Google:ClientSecret"]!;
});
//.AddTwitter(x =>
//{
//    x.ConsumerKey = builder.Configuration["Twitter:ConsumerKey"]!;
//    x.ConsumerSecret = builder.Configuration["Twitter:ConsumerSecret"]!;
//});


var app = builder.Build();
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
