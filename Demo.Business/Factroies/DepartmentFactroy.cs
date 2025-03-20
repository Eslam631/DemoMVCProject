using Demo.Business.DTO.DepartmentDto;
using Demo.Data.Access.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Business.Factroies
{
   public static class DepartmentFactroy
    {
        public static DepartmentGetAllDto ToDepartmentGetAllDto(this Department department)
        {
            return new DepartmentGetAllDto()
            {
                Code = department.Code,
                Name = department.Name,

                Description = department.Description,
                Id = department.Id,
                DateOfCreation = DateOnly.FromDateTime(department.CreatedOn.Value)
            };
            

        }

        public static DepartmentByIdDto ToDepartmentByIdDto(this Department Department) {
         return   new DepartmentByIdDto()
            {
                Code = Department.Code,
                Name = Department.Name,
                Description = Department.Description,
                Id = Department.Id,
                CreatedBy = Department.CreatedBy,
                CreatedOn = DateOnly.FromDateTime(Department.CreatedOn.Value),
                LastModifiedBy = Department.LastModifiedBy,
                LastModifiedOn = DateOnly.FromDateTime(Department.LastModifiedOn.Value),

            };
        }



        public static Department ToDepartment(this AddDepartmentDto departmentDto)
        {
            return new Department()
            {
                Code = departmentDto.Code,
                Name = departmentDto.Name,
                CreatedOn = departmentDto.CreateOn.ToDateTime(new TimeOnly()),
                Description = departmentDto.Description,

            };
        }
        public static Department ToDepartment(this UpdateDepartmentDto departmentDto)
        {
            return new Department()
            {
                 Id = departmentDto.Id,
                Code = departmentDto.Code,
                Name = departmentDto.Name,
                CreatedOn = departmentDto.CreatedOn.ToDateTime(new TimeOnly()),
                Description = departmentDto.Description,

            };
        }
    }
}
