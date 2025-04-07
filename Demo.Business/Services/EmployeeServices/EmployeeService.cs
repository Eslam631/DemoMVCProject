using AutoMapper;
using Demo.Business.DTO.EmployeeDto;
using Demo.Business.Factroies;
using Demo.Data.Access.Models.EmployeeModel;
using Demo.Data.Access.Repositories.EmployeeRepo;
using Demo.Data.Access.Repositories.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Business.Services.EmployeeServices
{
    public class EmployeeService(IUnitOfWork _unitOfWork,IMapper _mapper) : IEmployeeService
    {
        public IEnumerable<GetAllEmployeeDto> GetAllEmployee(string? Search)
        {
           IEnumerable<Employee> listOfEmployee;
            if (string.IsNullOrWhiteSpace(Search))
                listOfEmployee = _unitOfWork.EmployeeRepository.GetAll();

            else
                listOfEmployee = _unitOfWork.EmployeeRepository.GetAll(E => E.Name.ToLower().Contains(Search.ToLower()));


            return _mapper.Map<IEnumerable<Employee>,IEnumerable<GetAllEmployeeDto>>(listOfEmployee);
       
        }
        public EmployeeByIdDto? GetEmployeeById(int id)
        {
            var Employee= _unitOfWork.EmployeeRepository.GetById(id);
            return Employee == null ? null : _mapper.Map<Employee, EmployeeByIdDto>(Employee);  ;
        }
        public int AddEmployee(AddEmployeeDto EmployeeDto)
        {
                _unitOfWork.EmployeeRepository.Add(_mapper.Map<AddEmployeeDto,Employee>(EmployeeDto));
            var Result = _unitOfWork.SaveChange();
            if (Result > 0)

                return Result;

            else return -1;
            
        }

        public bool DeleteEmployee(int id)
        {
           var Employee= _unitOfWork.EmployeeRepository.GetById(id);
            if(Employee != null)
            {
                    
               Employee.IsDeleted = true;
                    _unitOfWork.EmployeeRepository.Update(Employee);
            return _unitOfWork.SaveChange() > 0 ? true : false;
            }
             return false;
        }



        public int UpdateEmployee(UpdateEmployeeDto EmployeeDto)
        {
            var Employee=_mapper.Map<UpdateEmployeeDto,Employee>(EmployeeDto);

                _unitOfWork.EmployeeRepository.Update(Employee);
            var Result = _unitOfWork.SaveChange();

            if (Result > 0) return Result;
            else return -1;
            
        }
    }
}
