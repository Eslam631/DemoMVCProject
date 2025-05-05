using AutoMapper;
using Demo.Business.DTO.EmployeeDto;
using Demo.Data.Access.Models.EmployeeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Business.Profiles
{
   public class MappingProfiles:Profile
    {

        public MappingProfiles()
        {
            CreateMap<Employee, GetAllEmployeeDto>().ForMember(dest => dest.Gender, Option => Option.MapFrom(Src => Src.Gender)).
                ForMember(dest => dest.EmployeeType, Option => Option.MapFrom(Src => Src.EmployeeType))
                .ForMember(dest=>dest.Department,Option=>Option.MapFrom(Src=> Src.Department != null ? Src.Department.Name : "No Department"));
            CreateMap<Employee, EmployeeByIdDto>().ForMember(dest => dest.Gender, Option => Option.MapFrom(Src => Src.Gender)).
                ForMember(dest => dest.EmployeeType, Option => Option.MapFrom(Src => Src.EmployeeType)).
                ForMember(dest=>dest.HiringDate,Option=>Option.MapFrom(Src=>DateOnly.FromDateTime(Src.HiringDate)))
                 .ForMember(dest => dest.Department, Option => Option.MapFrom(Src => Src.Department!=null?Src.Department.Name:"No Department"));
            CreateMap<AddEmployeeDto, Employee>().ForMember(dest=>dest.HiringDate,Option=>Option.MapFrom(Src=>Src.HiringDate.ToDateTime(TimeOnly.MinValue)));
            CreateMap<UpdateEmployeeDto, Employee>().ForMember(dest => dest.HiringDate, Option => Option.MapFrom(Src => Src.HiringDate.ToDateTime(TimeOnly.MinValue)));
        }

    }
}
