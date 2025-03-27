using Demo.Business.DTO.EmployeeDto;
using Demo.Business.Factroies;
using Demo.Data.Access.Repositories.EmployeeRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Business.Services.EmployeeServices
{
    public class EmployeeService(IEmployeeRepository _employeeRepository) : IEmployeeService
    {
        public int AddEmployee(AddEmployeeDto EmployeeDto)
        {
          var Result=  _employeeRepository.Add(EmployeeDto.ToEntity());
            if (Result > 0)

                return Result;

            else return -1;
            
        }

        public bool DeleteEmployee(int id)
        {
           var Employee= _employeeRepository.GetById(id);
            if(Employee != null)
            {
               var Result= _employeeRepository.Delete(Employee);
                if (Result>0) 
                    return true;
            }
             return false;
        }

        public IEnumerable<GetAllEmployeeDto> GetAllEmployee()
        {
          var ListEmployee = _employeeRepository.GetAll();

                return ListEmployee.Select(E => E.ToReturnEmployeeDto());
        }

        public EmployeeByIdDto? GetEmployeeById(int id)
        {
            var Employee=_employeeRepository.GetById(id);
            if (Employee != null)
                return Employee.ToEmployeeById();
            return null;
        }

        public int UpdateEmployee(UpdateEmployeeDto EmployeeDto)
        {
            var Result=_employeeRepository.Update(EmployeeDto.ToEntity());

            if (Result > 0) return Result;
            else return -1;
            
        }
    }
}
