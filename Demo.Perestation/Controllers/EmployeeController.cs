using Demo.Business.DTO.EmployeeDto;
using Demo.Business.Services.EmployeeServices;
using Demo.Data.Access.Models.Shared.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Perestation.Controllers
{
    public class EmployeeController(IEmployeeService _employeeService,IWebHostEnvironment _environment,ILogger< EmployeeController> _logger) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
       var Employees=_employeeService.GetAllEmployee();
            return View(Employees);
        }

        [HttpGet]
        #region Create Employee
        public IActionResult Create()
        {

            return View();


        }
        [HttpPost]

        public IActionResult Create(AddEmployeeDto addEmployeeDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
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
               
          

                return View(addEmployeeDto); 
            



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
        public IActionResult Edit(int? id )
        {
            if (id == null)
                return BadRequest();
            else
            {
              var Employee=  _employeeService.GetEmployeeById(id.Value);
                if(Employee == null)
                    return NotFound();
                else
                {
                    var EmployeeDto = new UpdateEmployeeDto()
                    {
                        Address = Employee.Address,
                        Age = Employee.Age,
                        Email = Employee.Email,
                        HiringDate = Employee.HiringDate,
                        Id = Employee.Id,
                        IsActive = Employee.IsActive,
                        Name = Employee.Name,
                        PhoneNumber = Employee.PhoneNumber,
                        Salary = Employee.Salary,
                        EmployeeType = Enum.Parse<EmployeeType>(Employee.EmployeeType),
                        Gender = Enum.Parse<Gender>(Employee.Gender),

                    };
                    return View(EmployeeDto);
                }
            }
            

            
            

        }


        [HttpPost]
       
        public IActionResult Edit([FromRoute]int? id,UpdateEmployeeDto updateEmployee) {
            if (id == null || id!=updateEmployee.Id)
                return BadRequest();
            if (!ModelState.IsValid)
                return View(updateEmployee);
            else {
                try
                {
                    var Result =_employeeService.UpdateEmployee(updateEmployee);
                    if (Result > 0)
                    return RedirectToAction(nameof(Index));
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Can't Update Employee");
                        return View(updateEmployee);
                    }

                   

                }
                catch (Exception ex)
                {
                    if (_environment.IsDevelopment())
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                        return View(updateEmployee);
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
     
        public IActionResult Delete(int id) {
        
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
