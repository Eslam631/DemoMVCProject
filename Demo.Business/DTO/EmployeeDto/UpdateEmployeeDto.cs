using Demo.Data.Access.Models.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Business.DTO.EmployeeDto
{
   public class UpdateEmployeeDto
    {


    public int Id { get; set; } 
        public string Name { get; set; } = string.Empty;

        public int Age { get; set; }
        public string? Address { get; set; }
        public bool IsActive { get; set; }
        public decimal Salary { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        public DateOnly HiringDate { get; set; }

        public Gender Gender { get; set; } 
        public EmployeeType EmployeeType { get; set; }

        public int CreateBy {  get; set; }
        public int LastModifiedBy {  get; set; }
    }
}
