using Demo.Data.Access.Models.EmployeeModel;
using Demo.Data.Access.Repositories.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Access.Repositories.EmployeeRepo
{
   public interface IEmployeeRepository:IGenericRepository<Employee>
    {
    }
}
