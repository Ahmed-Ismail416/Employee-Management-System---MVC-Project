using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        //GetAll
        IEnumerable<TEntity> GetAll(bool withtracking = false);
        IEnumerable<TResult> GetAll<TResult>(Expression<Func<TEntity, TResult>> selector);
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> Predicate);
        //GetById
        TEntity? GetById(int id);
        //Add
        int Insert(TEntity Entity);
        //Update
        void Update(TEntity Entity);
        //Delete
        void Delete(TEntity Entity);
    }
}
