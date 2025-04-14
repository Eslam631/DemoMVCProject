using Demo.Data.Access.Models.IdentityModel;

using Demo.Perestation.Untilities;
using Demo.Perestation.ViewModels.AccountVM;
using Demo.Perestation.Views.Account.PartialViews;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Email = Demo.Perestation.Untilities.Email;

namespace Demo.Perestation.Controllers
{
    public class AccountController(UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManager) : Controller
    {
        #region Register
        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(RegisterViewModel registerViewModel)
        {

            if (!ModelState.IsValid)
                return View(registerViewModel);

            var User = new ApplicationUser()
            {
                FristName = registerViewModel.FristName,
                Email = registerViewModel.Email,
                LastName = registerViewModel.LastName,

                UserName = registerViewModel.UserName,
            };

            var Result = _userManager.CreateAsync(User, registerViewModel.Password).Result;

            if (Result.Succeeded)
                return RedirectToAction(nameof(Login));
            else
            {
                foreach (var Error in Result.Errors)
                {
                    ModelState.AddModelError(string.Empty, Error.Description);
                }
                return View(registerViewModel);
            }
        }



        #endregion

        #region Login

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]

        public IActionResult Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);
            else
            {
                var user = _userManager.FindByEmailAsync(viewModel.Email).Result;
                if (user != null)
                {
                    var Flag = _userManager.CheckPasswordAsync(user, viewModel.Password).Result;
                    if (Flag)
                    {

                        var result = _signInManager.PasswordSignInAsync(user, viewModel.Password, viewModel.RememberMe, false).Result;

                        if (result.Succeeded)

                            return RedirectToAction(nameof(HomeController.Index), "Home");




                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "form is not found");

                    }
                }
                return View(viewModel);
            }

        }

        #endregion

        public new IActionResult SignOut()
        {
            _signInManager.SignOutAsync().GetAwaiter().GetResult();
            return RedirectToAction(nameof(Login));
        }


        #region ForgetPassword
        [HttpGet]
        public IActionResult ForgetPassword() => View();

        [HttpPost]
        public IActionResult SendResetPassword(ForgetViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var User = _userManager.FindByEmailAsync(viewModel.Email).Result;
                if (User is not null)
                {
                    var Token = _userManager.GeneratePasswordResetTokenAsync(User).Result;
                    var Body = Url.Action(nameof(ResetPassword), "Account", new { email = viewModel.Email, Token }, Request.Scheme);
                    Email email = new Email()
                    {
                        To = viewModel.Email,
                        Subject = "Forget Password",
                        Body = Body,
                    };

                    EmailSending.SendEmail(email);

                    return RedirectToAction(nameof(CheckInbox));

                }



            }
            ModelState.AddModelError(string.Empty, "Invalid Operation");
            return View(nameof(ForgetPassword), viewModel);

        }

        [HttpGet]
        public IActionResult CheckInbox() => View();


        [HttpGet]
        public IActionResult ResetPassword(string email,string token) 
        {
            TempData["email"]=email;
            TempData["token"]=token;
            
            
            return View(); }

        [HttpPost]
        public IActionResult ResetPassword(ResetPasswordViewModel viewModel) 
        {

            if (ModelState.IsValid) {
           
                string Email=TempData["email"]as string??string.Empty ;
                string Token=TempData["token"]as string??string.Empty ;

                var User = _userManager.FindByEmailAsync(Email).Result;
                if (User is not null) {

                var Result=    _userManager.ResetPasswordAsync(User, Token, viewModel.Password).Result;

                    if (Result.Succeeded) 
                    
                        return RedirectToAction(nameof(Login));
                    else
                    {
                        foreach (var item in Result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, item.Description); 
                        }
                    }
                    
                    
                
                }

            }
                return View(nameof(ForgetPassword));
        
        }
        #endregion
    }
}
