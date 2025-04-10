using Demo.Business.DTO.DepartmentDto;
using Demo.Business.Services.DepartmentSevices;
using Demo.Perestation.ViewModels.DepartmentVM;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Perestation.Controllers
{
    public class DepartmentController(IDepartmentService _departmentService,ILogger<DepartmentController> _logger,
        IWebHostEnvironment _environment) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var department = _departmentService.GetAllDepartment();
            return View(department);
        }

        #region Create Department
        [HttpGet]
        public IActionResult Create() => View();


        [HttpPost]

        public IActionResult Create(DepartmentViewModel  departmentViewModel)
         {
            if (ModelState.IsValid) {
                try
                {
                 var  departmentDto= new AddDepartmentDto()
                 {
                      Code = departmentViewModel.Code,
                       CreateOn=departmentViewModel.CreationOn,
                        Description = departmentViewModel.Description,
                         Name = departmentViewModel.Name,
                 };
                    string Message;
                    var Result = _departmentService.AddDepartment(departmentDto);
                    if (Result > 0)
                        Message = $"Department {departmentViewModel.Name} Create Success";


                    else
                    
                       Message=$"Department {departmentViewModel.Name} Can't Be Created";


                    TempData["Message"]=Message;
                    return RedirectToAction(nameof(Index));
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
            
            
            return View(departmentViewModel);

            
        }

        #endregion


        #region Details of Department

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if(!id.HasValue)
                return BadRequest();  
         
            var Result=_departmentService.GetDepartmentById(id.Value);

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
                var result=_departmentService.GetDepartmentById(id.Value);

                if(result == null)
                    return NotFound();
                else
                {
                    return View(new DepartmentViewModel() { 
                   
                    
                         Code = result.Code,
                         Name = result.Name,
                          CreationOn=result.CreatedOn,
                           Description = result.Description,
                    
                    });
                }
            }
        
        }


        [HttpPost]
        public IActionResult Edit([FromRoute] int id,DepartmentViewModel departmentViewModel) {

            if (ModelState.IsValid)
            {
            
                try
                {
                    var UpdateDepartment = _departmentService.UpdateDepartment(new UpdateDepartmentDto()
                    {
                        Id = id,
                        Name = departmentViewModel.Name,
                        Code = departmentViewModel.Code,
                        CreatedOn = departmentViewModel.CreationOn,
                        Description = departmentViewModel.Description,

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
            return View(departmentViewModel);
        }

        #endregion


        #region Delete Department

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            else
            {
                var Department = _departmentService.GetDepartmentById(id.Value);
                if (Department == null)
                    return NotFound();
                return View(Department);
            }
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id == 1)
                return BadRequest();
            else
            {
                try
                {
                    var Result = _departmentService.DeleteDepartment(id);

                    if (Result)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "DepartmentByIdDto Can Not Deleted");
                        return RedirectToAction(nameof(Delete), new {id});
                    }

                }
                catch (Exception  ex)
                {
                    if (_environment.IsDevelopment())
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                        return RedirectToAction(nameof(Index));
                    }
                    else {
                    
                        _logger.LogError(string.Empty, ex.Message);
                        return View("ErrorView", ex);
                    
                    }
                 
                }
            }


        }
        #endregion
    }
}
