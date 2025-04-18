using Demo.Data.Access.Models.IdentityModel;
using Demo.Perestation.ViewModels.RolesVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Perestation.Controllers
{
    [Authorize]
    public class RolesController(RoleManager<IdentityRole> _roleManager) : Controller
    {
        [HttpGet]
        public IActionResult Index(string? RolesSearchName)
        {
          var Roles= _roleManager.Roles.ToList();

            if (RolesSearchName != null)
            {
                Roles=_roleManager.Roles.Where(R=>R.Name==RolesSearchName).ToList();
            }

            var RoleView = Roles.Select(R => new RoleViewModel()
            {
                 Id = R.Id,
                  Name=R.Name
            });
                     
            return View(RoleView);
        }

        #region Create Role

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(CreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    var Role = new IdentityRole()
                    {
                        Name = viewModel.Name,

                    };

                    var Result = _roleManager.CreateAsync(Role).Result;

                    if (Result.Succeeded)
                        return RedirectToAction(nameof(Index));
                    else
                        ModelState.AddModelError(string.Empty, "Operation InValid");


                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty, ex.Message);
                }

            }
            return View(viewModel);
        } 
        #endregion

        #region Edit Role
        [HttpGet]
        public IActionResult Edit(string? id)
        {

            if (id == null)
                return BadRequest();

            var Role = _roleManager.FindByIdAsync(id).Result;

            if (Role == null)
                return NotFound();

            var RoleViewModel= new CreateViewModel()
            {
                
                Name = Role.Name
            };

            return View(RoleViewModel);



        }

        [HttpPost]
        public IActionResult Edit([FromRoute] string id, CreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

                var Role = new IdentityRole()
                {
                    Id = id,
                    Name = viewModel.Name,
                    
                    
                };

                try
                {
                    var UpdateRole = _roleManager.UpdateAsync(Role).Result;

                    if (UpdateRole.Succeeded)
                        return RedirectToAction(nameof(Index));
                    else
                        foreach (var err in UpdateRole.Errors)
                            ModelState.AddModelError(string.Empty, err.Description);


                }
                catch (Exception)
                {

                    ModelState.AddModelError(string.Empty, "Invalid Operation");
                }


            }

            return View(viewModel);
        }

        #endregion


        #region Detalis

        [HttpGet]

        public IActionResult Details(string? id )
        {
            if(id==null)
                return BadRequest();

            var Role=_roleManager.FindByIdAsync(id).Result;
            if (Role == null) return NotFound();

            var RoleViewModel = new RoleViewModel() {
            
                 Id=Role.Id,
                  Name=Role.Name
            
            };
            return View(RoleViewModel);

        }


        #endregion


        #region Delete

        [HttpGet]
        public IActionResult Delete(string? id) 
        {
            if (id == null)
                return BadRequest();

            var Role = _roleManager.FindByIdAsync(id).Result;
            if (Role == null) return NotFound();

            var RoleViewModel = new RoleViewModel()
            {

                Id = Role.Id,
                Name = Role.Name

            };
            return View(RoleViewModel);
        }


        [HttpPost]
        public IActionResult DeleteRole(string Id)
        {



            var user = _roleManager.FindByIdAsync(Id).Result;



            if (user != null)
            {
                try
                {

                    var Result = _roleManager.DeleteAsync(user).Result;
                    if (Result != null)
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
