
using Demo.Data.Access.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Access.Repositories.GenericRepo
{
  public interface IGenericRepository<T>where T :BaseEntity
    {

        int Add(T Model);
        int Delete(T Model);
        IEnumerable<T> GetAll(bool WithTracking = false);
        IEnumerable<TResult> GetAll<TResult>(Expression<Func<T,TResult>> selector);
        T? GetById(int id);
        int Update(T Model);
    }
}
