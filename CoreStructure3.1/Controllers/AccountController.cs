using CoreStructure3._1.Models;
using CoreStructure3._1.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreStructure3._1.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [Route("signup")]
        public IActionResult SignUp()
        {
            return View();
        }

        [Route("signup")]
        [HttpPost]
        public async Task<IActionResult> Signup(SignUpUserModel userModel)
        {
            if (ModelState.IsValid)
            {
                // write your code
                var result = await _accountRepository.CreateUserAsync(userModel);
                if (!result.Succeeded)
                {
                    foreach (var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage.Description);
                    }

                    return View(userModel);
                }

                ModelState.Clear();
                //return RedirectToAction("ConfirmEmail", new { email = userModel.Email });
            }

            return View(userModel);
        }

        [Route("login")]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        public IActionResult SignIn(SignInModel signInModel)
        {
            if (ModelState.IsValid)
            {
                var result = _accountRepository.PasswordSignInAsync(signInModel);
                if (ModelState.IsValid)
                {
                    return RedirectToAction("");
                }

                ModelState.AddModelError("", "Invalid Credentials");
            }

            return View(signInModel);
        }
    }
}