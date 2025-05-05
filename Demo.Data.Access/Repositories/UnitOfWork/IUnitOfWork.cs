using Demo.Data.Access.Repositories.DepartmentRepo;
using Demo.Data.Access.Repositories.EmployeeRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Access.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IEmployeeRepository EmployeeRepository { get; }
        public IDepartmentRepository DepartmentRepository { get; }

        int SaveChange();
    }
}
