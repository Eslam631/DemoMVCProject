using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Business.DTO.DepartmentDto
{
    public class DepartmentByIdDto
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; }

        public int Id { get; set; }//pk
        public int CreatedBy { get; set; }//User Id 

        public DateOnly CreatedOn { get; set; }

        public int LastModifiedBy { get; set; } //user id

        public DateOnly LastModifiedOn { get; set; }

        public bool IsDeleted { get; set; }  //Soft Delete
    }
}
