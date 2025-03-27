using Demo.Business.DTO.EmployeeDto;
using Demo.Data.Access.Models.EmployeeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Business.Factroies
{
   public static class EmployeeFactroy
    {


        public static Employee ToEntity(this AddEmployeeDto employeeDto)
        {


            return new Employee()
            {
                Name = employeeDto.Name,
                Address = employeeDto.Address,
                Age = employeeDto.Age,
                CreatedBy = employeeDto.CreatedBy,
                Email = employeeDto.Email,
                EmployeeType = employeeDto.EmployeeType,
                Gender = employeeDto.Gender,
                PhoneNumber = employeeDto.PhoneNumber,
                Salary = employeeDto.Salary,
                IsActive = employeeDto.IsActive,
                HiringDate = employeeDto.HiringDate.ToDateTime(new TimeOnly()),
                LastModifiedBy=employeeDto.LastModifiedBy,
                 

            };
            

        }

        public static Employee ToEntity(this UpdateEmployeeDto employeeDto)
        {


            return new Employee()
            {
                 Id= employeeDto.Id,
                Name = employeeDto.Name,
                Address = employeeDto.Address,
                Age = employeeDto.Age,
              
                Email = employeeDto.Email,
                EmployeeType = employeeDto.EmployeeType,
                Gender = employeeDto.Gender,
                PhoneNumber = employeeDto.PhoneNumber,
                Salary = employeeDto.Salary,
                IsActive = employeeDto.IsActive,
                HiringDate = employeeDto.HiringDate.ToDateTime(new TimeOnly()),
                LastModifiedBy = employeeDto.LastModifiedBy,


            };


        }

        public static GetAllEmployeeDto ToReturnEmployeeDto(this Employee employee)
        {

            return new GetAllEmployeeDto()
            {

                Id = employee.Id,
                Name = employee.Name,

                Age = employee.Age,
                Email = employee.Email,
                EmployeeType = employee.EmployeeType.ToString(),
                 Gender=employee.Gender.ToString(),
                  IsActive = employee.IsActive,
                   Salary=employee.Salary,



            };
        }


        public static EmployeeByIdDto ToEmployeeById(this Employee employee)
        {
            return new EmployeeByIdDto()
            {
                Id = employee.Id,
                Name = employee.Name,
                Salary = employee.Salary,
                Email = employee.Email,
                IsActive = employee.IsActive,
                Gender = employee.Gender.ToString(),
                EmployeeType = employee.EmployeeType.ToString(),
                Address = employee.Address,
                Age = employee.Age,
                HiringDate = DateOnly.FromDateTime(employee.HiringDate),
                PhoneNumber = employee.PhoneNumber,


            };
        }
    }
}
