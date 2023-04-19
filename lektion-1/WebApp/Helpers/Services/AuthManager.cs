using Microsoft.AspNetCore.Identity;
using WebApp.Models.Dtos;
using WebApp.Models.Identity;

namespace WebApp.Helpers.Services
{
    public class AuthManager
    {
        private readonly UserManager<CustomIdentityUser> _userManager;
        private readonly SignInManager<CustomIdentityUser> _signInManager;
        private readonly AddressManager _addressService;

        public AuthManager(UserManager<CustomIdentityUser> userManager, SignInManager<CustomIdentityUser> signInManager, AddressManager addressService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _addressService = addressService;
        }

        public async Task<bool> RegisterAsync(UserRegisterModel model)
        {
            return false;
        }
    }
}
