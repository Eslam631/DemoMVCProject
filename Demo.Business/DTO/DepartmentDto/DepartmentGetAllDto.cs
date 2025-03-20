using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Business.DTO.DepartmentDto
{
  public class DepartmentGetAllDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public string Code { get; set; } = string.Empty;

      public DateOnly DateOfCreation { get; set; }

    }
}
