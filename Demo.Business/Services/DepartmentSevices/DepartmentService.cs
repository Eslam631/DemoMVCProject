using Demo.Business.DTO.DepartmentDto;
using Demo.Business.Factroies;
using Demo.Data.Access.Repositories.DepartmentRepo;
using Demo.Data.Access.Repositories.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Business.Services.DepartmentSevices
{
    public class DepartmentService(IUnitOfWork _unitOfWork) : IDepartmentService
    {

        public IEnumerable<DepartmentGetAllDto> GetAllDepartment()
        {

            var departments = _unitOfWork.DepartmentRepository.GetAll();


            var Return = departments.Select(D => D.ToDepartmentGetAllDto());

            return Return;
        }


        public DepartmentByIdDto? GetDepartmentById(int id)
        {
            var Department = _unitOfWork.DepartmentRepository.GetById(id);

            if (Department == null) return null;
            else
                return Department.ToDepartmentByIdDto();

        }


        public int AddDepartment(AddDepartmentDto departmentDto)
        {

                _unitOfWork.DepartmentRepository.Add(departmentDto.ToDepartment());

            int Result = _unitOfWork.SaveChange(); 

            if (Result > 0)
                return Result;
            else
                return -1;

        }


        public int UpdateDepartment(UpdateDepartmentDto departmentDto)
        {

                _unitOfWork.DepartmentRepository.Update(departmentDto.ToDepartment());
            int Result =_unitOfWork.SaveChange();
            if (Result > 0)
                return Result;
            else
                return -1;
        }


        public bool DeleteDepartment(int id)
        {

            var Department = _unitOfWork.DepartmentRepository.GetById(id);
            if (Department == null) return false;
            else
            {
                    _unitOfWork.DepartmentRepository.Delete(Department);
                int Result = _unitOfWork.SaveChange(); 

                if (Result > 0)
                    return true;
                else return false;
            }
        }
    }
}
