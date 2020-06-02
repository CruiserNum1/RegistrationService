using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RegistrationService.Models;
using RegistrationService.ViewModels;

namespace RegistrationService.Controllers.api
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public UserController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [Authorize]
        [HttpGet]
        [Route("About")]
        public async Task<IActionResult> About()
        {
            string userName = HttpContext.User.Identity.Name;
            User user = await _userManager.FindByNameAsync(userName);
            
            if (user == null)
            {
                return NotFound();
            }

            return Ok(new UserViewModel(user));
        }
    }
}