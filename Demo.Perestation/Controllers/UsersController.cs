using Demo.Data.Access.Models.IdentityModel;
using Demo.Perestation.ViewModels.UsersVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo.Perestation.Controllers
{
    [Authorize]
    public class UsersController(UserManager<ApplicationUser> _userManager) : Controller
    {
        [HttpGet]
        public IActionResult Index(string? UsersSearchName)
        {

          var Users=  _userManager.Users.ToList();
            if (UsersSearchName != null)
            {
                Users = _userManager.Users.Where(U => U.FristName == UsersSearchName).ToList();
            }
            var UserView = Users.Select(E => new UsersViewModel()
            {
                Id = E.Id,
                FName = E.FristName,
                LName = E.LastName,
                Email = E.Email,
                PhoneNumber = E.PhoneNumber,

            });

            return View(UserView);
        }

        [HttpGet]
        public IActionResult Details(string? Id)
        {
            if (Id == null)
                return BadRequest();

            var User = _userManager.FindByIdAsync(Id).Result;
            if (User == null)
                return NotFound();
           else 
            {
                var UserDetailsView = new UserDetailsViewModel()
                {
                     Email=User.Email,
                      FName=User.FristName,
                      PhoneNumber=User.PhoneNumber,
                       Id=Id,
                        LName=User.LastName,
                         UserName=User.UserName
                         

                };

                return View(UserDetailsView);
            }






        }


        #region Update
        [HttpGet]

        public IActionResult Edit(string? Id) 
        {
        
            if (Id == null)
                return BadRequest();

            var User = _userManager.FindByIdAsync(Id).Result;
            if (User == null) return NotFound();

            else {
          




                return View(new EditUserViewModel()
                {
                    FName = User.FristName,
                    PhoneNumber = User.PhoneNumber,
                    LName = User.LastName
                });
                   
            }
           
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] string id,EditUserViewModel viewModel) {

            if (ModelState.IsValid)
            {
                var user = _userManager.FindByIdAsync(id).Result;


                user.FristName = viewModel.FName;
                user.LastName = viewModel.LName;
                user.PhoneNumber = viewModel.PhoneNumber;

                var Result=_userManager.UpdateAsync(user).Result;

                if (Result.Succeeded) 
                    return RedirectToAction(nameof(Index));
           
            }
            return View(viewModel);
        
        }

        #endregion

        #region Delete

        [HttpGet]
        public IActionResult Delete(string? Id)
        {
            if (Id == null)
                return BadRequest();

            var User = _userManager.FindByIdAsync(Id).Result;
            if (User == null)
                return NotFound();
            else
            {
                var UserDetailsView = new UserDetailsViewModel()
                {
                    Email = User.Email,
                    FName = User.FristName,
                    PhoneNumber = User.PhoneNumber,
                    Id = Id,
                    LName = User.LastName,
                    UserName = User.UserName


                };

                return View(UserDetailsView);
            }


        }

        [HttpPost]
        public IActionResult DeleteUser(string Id)
        {
          
           
            
            var user=  _userManager.FindByIdAsync(Id).Result;



            if (user!=null)
            {
                try
                {
                 
                  var Result=  _userManager.DeleteAsync(user).Result;
                    if(Result!=null)
                        return RedirectToAction(nameof(Index));
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid Operation");
                    }


                }
                catch (Exception)
                {

                    ModelState.AddModelError(string.Empty, "Invalid Operation");
                }
            }

          return NotFound();
        
        }
        #endregion
    }
}
