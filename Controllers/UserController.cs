using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RegistrationService.Models;
using RegistrationService.ViewModels;

namespace RegistrationService.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        public UserController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> About()
        {
            string userName = HttpContext.User.Identity.Name;
            User user = await _userManager.FindByNameAsync(userName);
            
            if (user == null)
            {
                return NotFound();
            }

            return View(new UserViewModel(user));
        }

        [HttpPost]
        public async Task<IActionResult> Search(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return BadRequest("Строка пуста");
            }

            User user = await _userManager.FindByEmailAsync(search);
            if (user == null)
            {
                return NotFound("Пользователь не найден");
            }

            return View("About", new UserViewModel(user));
        }
    }
}