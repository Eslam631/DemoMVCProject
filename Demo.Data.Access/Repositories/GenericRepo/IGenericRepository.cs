
using Demo.Data.Access.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Access.Repositories.GenericRepo
{
  public interface IGenericRepository<TEntity>where TEntity :BaseEntity
    {

        void Add(TEntity Model);
        void Delete(TEntity Model);
        IEnumerable<TEntity> GetAll(bool WithTracking = false);
        IEnumerable<TResult> GetAll<TResult>(Expression<Func<TEntity,TResult>> selector);
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity,bool>> Predicate);
        TEntity? GetById(int id);
     void Update(TEntity Model);
        
    }
}
