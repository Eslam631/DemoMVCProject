using AutoMapper;
using Demo.Business.DTO.EmployeeDto;
using Demo.Business.Factroies;
using Demo.Data.Access.Models.EmployeeModel;
using Demo.Data.Access.Repositories.EmployeeRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Business.Services.EmployeeServices
{
    public class EmployeeService(IEmployeeRepository _employeeRepository,IMapper _mapper) : IEmployeeService
    {
        public IEnumerable<GetAllEmployeeDto> GetAllEmployee()
        {
            var ListEmployee = _employeeRepository.GetAll(E => new GetAllEmployeeDto()
            {
                Id = E.Id,
                Name = E.Name,
                Salary = E.Salary,
                Age = E.Age,
                Email = E.Email,
                EmployeeType = E.EmployeeType.ToString(),
                Gender = E.Gender.ToString(),
                IsActive = E.IsActive,

            });

            //return _mapper.Map<IEnumerable<Employee>,IEnumerable<GetAllEmployeeDto>>(ListEmployee);
            return ListEmployee;
        }
        public EmployeeByIdDto? GetEmployeeById(int id)
        {
            var Employee=_employeeRepository.GetById(id);
            return Employee == null ? null : _mapper.Map<Employee, EmployeeByIdDto>(Employee);  ;
        }
        public int AddEmployee(AddEmployeeDto EmployeeDto)
        {
          var Result=  _employeeRepository.Add(_mapper.Map<AddEmployeeDto,Employee>(EmployeeDto));
            if (Result > 0)

                return Result;

            else return -1;
            
        }

        public bool DeleteEmployee(int id)
        {
           var Employee= _employeeRepository.GetById(id);
            if(Employee != null)
            {
                    
               Employee.IsDeleted = true;
            return _employeeRepository.Update(Employee)>0?true:false;
            }
             return false;
        }



        public int UpdateEmployee(UpdateEmployeeDto EmployeeDto)
        {
            var Employee=_mapper.Map<UpdateEmployeeDto,Employee>(EmployeeDto);

            var Result=_employeeRepository.Update(Employee);

            if (Result > 0) return Result;
            else return -1;
            
        }
    }
}
