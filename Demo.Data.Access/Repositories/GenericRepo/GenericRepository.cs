using Demo.Data.Access.Data.Context;
using Demo.Data.Access.Models.DepartmentModel;
using Demo.Data.Access.Models.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Access.Repositories.GenericRepo
{
   public class GenericRepository<TEntity>(ApplicationDbContext _dbContext):IGenericRepository<TEntity>where TEntity : BaseEntity
    {
  
        public IEnumerable<TEntity> GetAll(bool WithTracking = false)
        {

            if (WithTracking)
                return _dbContext.Set<TEntity>().Where(E => E.IsDeleted != true).ToList();
            else

                return _dbContext.Set<TEntity>().Where(E => E.IsDeleted != true).AsNoTracking().ToList();




        }
        public TEntity? GetById(int id) => _dbContext.Set<TEntity>().Find(id);





        public void Add(TEntity entity)
        {

            _dbContext.Set<TEntity>().Add(entity);

          
        }
        public void Update(TEntity entity)
        {

            _dbContext.Update(entity);
          



        }

        public void Delete(TEntity entity)
        {

            _dbContext.Remove(entity);
         

        }

        public IEnumerable<TResult> GetAll<TResult>(Expression<Func<TEntity, TResult>> selector)
        {
            return _dbContext.Set<TEntity>().Where(E => E.IsDeleted != true).Select(selector).ToList();
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity,bool>> Predicate)
        {
           return _dbContext.Set<TEntity>()
         .Where(Predicate)
         .ToList();


          
        }
    }
}
