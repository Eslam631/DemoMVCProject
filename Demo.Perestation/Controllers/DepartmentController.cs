using Demo.Business.DTO.DepartmentDto;
using Demo.Business.Servers;
using Demo.Perestation.ViewModels.DepartmentVM;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Perestation.Controllers
{
    public class DepartmentController(IDepartmentServer _departmentServer,ILogger<DepartmentController> _logger,
        IWebHostEnvironment _environment) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var department = _departmentServer.GetAllDepartment();
            return View(department);
        }

        #region Create Department
        [HttpGet]
        public IActionResult Create() => View();


        [HttpPost]
        public IActionResult Create(AddDepartmentDto departmentDto)
        {
            if (ModelState.IsValid) {
                try
                {

                    var Result = _departmentServer.AddDepartment(departmentDto);
                    if(Result>0)
                        return RedirectToAction(nameof(Index));
                    else
                    {
                        ModelState.AddModelError("Message", "Department Can't Be Created");
                      

                    }
                }
               
                catch (Exception ex)
                {
                    if (_environment.IsDevelopment() )
                    {
                        // Development Environment==>Return Same View With Erroe
                       
                        ModelState.AddModelError(string.Empty, ex.Message);
                      

                    }
                    else
                    {
                        //Deployment=>Return View Error
                        _logger.LogError(ex.Message);

                       


                    }
                }

            }
            
            
            return View(departmentDto);

            
        }

        #endregion


        #region Details of Department

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if(!id.HasValue)
                return BadRequest();  
         
            var Result=_departmentServer.GetDepartmentById(id.Value);

            if (Result == null)
                return NotFound();
            return View(Result);
        }

        #endregion

        #region Edit

        [HttpGet]
        public IActionResult Edit(int? id) {
        
        if(!id.HasValue)
                return BadRequest();
            else
            {
                var result=_departmentServer.GetDepartmentById(id.Value);

                if(result == null)
                    return NotFound();
                else
                {
                    return View(new DepartmentEditViewModel() { 
                   
                    
                         Code = result.Code,
                         Name = result.Name,
                          CreationOn=result.CreatedOn,
                           Description = result.Description,
                    
                    });
                }
            }
        
        }


        [HttpPost]
        public IActionResult Edit([FromRoute] int id,DepartmentEditViewModel model) {

            if (ModelState.IsValid)
            {
            
                try
                {
                    var UpdateDepartment = _departmentServer.UpdateDepartment(new UpdateDepartmentDto()
                    {
                        Id = id,
                        Name = model.Name,
                        Code = model.Code,
                        CreatedOn = model.CreationOn,
                        Description = model.Description,

                    });
                    if (UpdateDepartment > 0)
                        return RedirectToAction(nameof(Index));
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Department Can Not Be Update ");
                    }


                }
                catch (Exception ex) {

                    if (_environment.IsDevelopment())
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                    else
                    {
                        _logger.LogError(ex, ex.Message);
                        return View("ErrorView",ex);
                    }

                }

            }
            return View(model);
        }

        #endregion
    }
}
