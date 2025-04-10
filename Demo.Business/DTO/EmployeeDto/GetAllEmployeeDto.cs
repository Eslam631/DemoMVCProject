using Demo.Data.Access.Models.Shared.Enums;
using Demo.Data.Access.Repositories.EmployeeRepo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Business.DTO.EmployeeDto
{
    public class GetAllEmployeeDto
    {
        public int Id { get; set; }
        public string Name {  get; set; }=string.Empty;

        public int Age { get; set; }
        [Display(Name ="Is Active")]
        public bool IsActive {  get; set; }

        [DataType(DataType.Currency)]
        public decimal Salary {  get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        public string Gender { get; set; }= string.Empty;
        [Display(Name ="Employee Type")]
        public string EmployeeType { get; set; } = string.Empty;
        public string? Department { get; set; }
    }
}
