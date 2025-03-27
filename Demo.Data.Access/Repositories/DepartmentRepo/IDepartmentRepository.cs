using Demo.Data.Access.Models.DepartmentModel;
using Demo.Data.Access.Repositories.GenericRepo;

namespace Demo.Data.Access.Repositories.DepartmentRepo
{
    public interface IDepartmentRepository:IGenericRepository<Department>
    {
    
    }
}