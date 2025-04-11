using Demo.Business.DTO.EmployeeDto;
using Demo.Business.Services.AttachmentServices;
using Demo.Business.Services.EmployeeServices;
using Demo.Data.Access.Models.EmployeeModel;
using Demo.Data.Access.Models.Shared.Enums;
using Demo.Perestation.ViewModels.EmployeeVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Perestation.Controllers
{
    [Authorize]
    public class EmployeeController(IEmployeeService _employeeService,IWebHostEnvironment _environment,ILogger< EmployeeController> _logger) : Controller
    {
        [HttpGet]
        public IActionResult Index(string? EmployeeSearchName)
        {
       var Employees=_employeeService.GetAllEmployee(EmployeeSearchName);
            return View(Employees);
        }

        [HttpGet]
        #region Create Employee
        public IActionResult Create()
        {

            return View();


        }
        [HttpPost]

        public IActionResult Create(EmployeeViewModel  employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var addEmployeeDto = new AddEmployeeDto()
                    {
                        EmployeeType = employeeViewModel.EmployeeType,
                        Name = employeeViewModel.Name,
                        Address = employeeViewModel.Address,
                        Age = employeeViewModel.Age,
                        CreatedBy = employeeViewModel.CreatedBy,
                        Email = employeeViewModel.Email,
                        Gender = employeeViewModel.Gender,
                        HiringDate = employeeViewModel.HiringDate,
                        IsActive = employeeViewModel.IsActive,
                        LastModifiedBy = employeeViewModel.LastModifiedBy,
                        PhoneNumber = employeeViewModel.PhoneNumber,
                        Salary = employeeViewModel.Salary,
                         DepartmentId = employeeViewModel.DepartmentId,
                          Image = employeeViewModel.Image,
                    };
                    var Result = _employeeService.AddEmployee(addEmployeeDto);
                    if (Result > 0)
                        return RedirectToAction(nameof(Index));
                    else
                        ModelState.AddModelError(string.Empty, "Can't  Create Employee");

                }
                catch (Exception ex)
                {
                    if (_environment.IsDevelopment())
                        ModelState.AddModelError(string.Empty, ex.Message);
                    else
                        _logger.LogError(ex.Message);
                   
                }
            }
               
          

                return View(employeeViewModel); 
            



        }
        #endregion

        #region Detalies

        [HttpGet]
        public IActionResult Details(int? id ) {

            if (id != null)
            {
               var Employee =_employeeService.GetEmployeeById(id.Value);
                if (Employee == null)
                    return NotFound();
                else
                return View(Employee);
            }
            else
                return BadRequest();
        
        }

        #endregion

        #region Edit

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return BadRequest();
            else
            {
                var Employee = _employeeService.GetEmployeeById(id.Value);
                if (Employee == null)
                    return NotFound();
                else
                {
                    

             
                    
                    EmployeeViewModel employeeViewModel;



                    employeeViewModel = new EmployeeViewModel()
                    {
                        Address = Employee.Address,
                        Age = Employee.Age,
                        Email = Employee.Email,
                        HiringDate = Employee.HiringDate,

                        IsActive = Employee.IsActive,
                        Name = Employee.Name,
                        PhoneNumber = Employee.PhoneNumber,
                        Salary = Employee.Salary,
                        EmployeeType = Enum.Parse<EmployeeType>(Employee.EmployeeType),
                        Gender = Enum.Parse<Gender>(Employee.Gender),
                        DepartmentId = Employee.DepartmentId,
                       
                       




                    };
                    
                    return View(employeeViewModel);
                }
            }
        }








        [HttpPost]
       
        public IActionResult Edit([FromRoute]int? id, EmployeeViewModel employeeViewModel )
        {
            if (id == null )
                return BadRequest();
            if (!ModelState.IsValid)
                return View(employeeViewModel);
            else {
                try
                {
                    var Result = _employeeService.UpdateEmployee(new UpdateEmployeeDto()
                    {
                        Address = employeeViewModel.Address,
                        Age = employeeViewModel.Age,
                        Email = employeeViewModel.Email,
                        HiringDate = employeeViewModel.HiringDate,
                         Id=id.Value,
                        IsActive = employeeViewModel.IsActive,
                        Name = employeeViewModel.Name,
                        PhoneNumber = employeeViewModel.PhoneNumber,
                        Salary = employeeViewModel.Salary,
                        EmployeeType = employeeViewModel.EmployeeType,
                        Gender = employeeViewModel.Gender,
                         DepartmentId = employeeViewModel.DepartmentId, 
                          Image = employeeViewModel.Image,
                          
                    });
                    if (Result > 0)
                    return RedirectToAction(nameof(Index));
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Can't Update Employee");
                        return View(employeeViewModel);
                    }

                   

                }
                catch (Exception ex)
                {
                    if (_environment.IsDevelopment())
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                        return View(employeeViewModel);
                    }
                    else
                    {
                        _logger.LogError(ex.Message);
                        return View("Error", ex);
                    }
                }


            }

        }
        #endregion

        #region Delete

        [HttpPost]
     
        public IActionResult Delete(int id) 
        {
        
            if(id==0)
                return BadRequest();

            try
            {
                var Result = _employeeService.DeleteEmployee(id);

                if (Result == true)
                    return RedirectToAction(nameof(Index));
                else
                    ModelState.AddModelError(string.Empty,"Employee Cn;t Delete");
                return RedirectToAction(nameof(Delete));

            }
            catch (Exception ex)
            {

                if (_environment.IsDevelopment()) {

                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    _logger.LogError(string.Empty, ex.Message);
                    return View("Error", ex);
                }
            }


       


        
        }

        #endregion
    }
}
