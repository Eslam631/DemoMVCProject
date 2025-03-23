using Demo.Data.Access.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Access.Repositories
{
   public class DepartmentRepository(ApplicationDbContext dbContext) : IDepartmentRepository
    {
        private readonly ApplicationDbContext _dbContext = dbContext;
        public IEnumerable<Department> GetAll(bool WithTracking = false)
        {

            if (WithTracking)
                return _dbContext.Departments.ToList();
            else

                return _dbContext.Departments.AsNoTracking().ToList();




        }
        public Department? GetById(int id) => _dbContext.Departments.Find(id);





        public int Add(Department department)
        {

            _dbContext.Departments.Add(department);

            return _dbContext.SaveChanges();
        }
        public int Update(Department department)
        {

            _dbContext.Update(department);
            return _dbContext.SaveChanges();



        }

        public int Delete(Department department)
        {

            _dbContext.Remove(department);
            return _dbContext.SaveChanges();

        }




    }
}
