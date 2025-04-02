using Demo.Data.Access.Models.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Business.DTO.EmployeeDto
{
   public class UpdateEmployeeDto
    {


    public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "Max Length should be 50 character")]
        [MinLength(5, ErrorMessage = "Max Length should be 5 character")]
        public string Name { get; set; } = string.Empty;
        [Range(22, 35)]
        public int Age { get; set; }
        [RegularExpression(@"^[1-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{4,10}-[a-zA-Z]{5,10}$",
         ErrorMessage = "Address must be like 123-Street-City-Country")]

        public string? Address { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
        public decimal Salary { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Display(Name = "Phone Number")]
        [Phone]
        public string? PhoneNumber { get; set; }

        public DateOnly HiringDate { get; set; }

        public Gender Gender { get; set; }

        [Display(Name = "Employee Type")]
        public EmployeeType EmployeeType { get; set; }

  
    }
}
