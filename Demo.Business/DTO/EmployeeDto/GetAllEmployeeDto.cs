using Demo.Data.Access.Models.Shared.Enums;
using Demo.Data.Access.Repositories.EmployeeRepo;
using System;
using System.Collections.Generic;
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

        public bool IsActive {  get; set; }
        public decimal Salary {  get; set; }
        public string? Email { get; set; }

        public string Gender { get; set; }= string.Empty;
        public string EmployeeType { get; set; } = string.Empty;
    }
}
