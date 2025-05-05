using Demo.Data.Access.Data.Context;
using Demo.Data.Access.Models.DepartmentModel;
using Demo.Data.Access.Repositories.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Access.Repositories.DepartmentRepo
{
    public class DepartmentRepository(ApplicationDbContext dbContext) : GenericRepository<Department>(dbContext), IDepartmentRepository
    {


    }
}
