using Demo.Business.DTO.EmployeeDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Business.Services.EmployeeServices
{
   public interface IEmployeeService
    {
        int AddEmployee(AddEmployeeDto EmployeeDto);
        bool DeleteEmployee(int id);
        IEnumerable<GetAllEmployeeDto> GetAllEmployee(string? Search);
        EmployeeByIdDto? GetEmployeeById(int id);
        int UpdateEmployee(UpdateEmployeeDto EmployeeDto);
    }
}
