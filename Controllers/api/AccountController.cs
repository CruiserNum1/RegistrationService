using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RegistrationService.Exceptions;
using RegistrationService.Models;
using RegistrationService.ViewModels;

namespace RegistrationService.Controllers.api
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, false, false);
            if (result.Succeeded)
            {
                return Ok("Авторизованы");
            }
            else
            {
                return Unauthorized("неавторизованы");
            }
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.BirthDate.Subtract(DateTime.Now).Days > 0)
                {
                    throw new InvalidBirthDateException("Неверное дата рождения");
                }

                User user = new User
                {
                    Email = model.Email,
                    UserName = model.Email,
                    BirthDate = model.BirthDate,
                    FullName = model.FullName
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return Ok("Регистрация прошла успешно");
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var error in result.Errors)
                    {
                        sb.AppendLine(error.Description);
                    }

                    return BadRequest(sb.ToString());
                }
            }

            return BadRequest();
        }
    }
}