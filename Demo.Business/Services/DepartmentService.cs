using Demo.Business.DTO.DepartmentDto;
using Demo.Business.Factroies;
using Demo.Data.Access.Repositories.DepartmentRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Business.Services
{
    public class DepartmentService(IDepartmentRepository _departmentRepository) : IDepartmentService
    {

        public IEnumerable<DepartmentGetAllDto> GetAllDepartment()
        {

            var departments = _departmentRepository.GetAll();


            var Return = departments.Select(D => D.ToDepartmentGetAllDto());

            return Return;
        }


        public DepartmentByIdDto? GetDepartmentById(int id)
        {
            var Department = _departmentRepository.GetById(id);

            if (Department == null) return null;
            else
                return Department.ToDepartmentByIdDto();

        }


        public int AddDepartment(AddDepartmentDto departmentDto)
        {

            int Result = _departmentRepository.Add(departmentDto.ToDepartment());

            if (Result > 0)
                return Result;
            else
                return -1;

        }


        public int UpdateDepartment(UpdateDepartmentDto departmentDto)
        {

            int Result = _departmentRepository.Update(departmentDto.ToDepartment());
            if (Result > 0)
                return Result;
            else
                return -1;
        }


        public bool DeleteDepartment(int id)
        {

            var Department = _departmentRepository.GetById(id);
            if (Department == null) return false;
            else
            {
                int Result = _departmentRepository.Delete(Department);

                if (Result > 0)
                    return true;
                else return false;
            }
        }
    }
}
