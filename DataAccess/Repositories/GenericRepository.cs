using DataAccess.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class GenericRepository<TEntity>(ApplicationDbContext _dbcontext) : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        // GetAll
        public IEnumerable<TEntity> GetAll(bool withtracking = false)
        {
            if (!withtracking)
                return _dbcontext.Set<TEntity>().Where(a => a.IsDeleted == false).AsNoTracking().ToList();
            else
                return _dbcontext.Set<TEntity>().Where(a => a.IsDeleted == false).ToList();
        }
        public IEnumerable<TResult> GetAll<TResult>(Expression<Func<TEntity, TResult>> selector)
        {
            return _dbcontext.Set<TEntity>().Where(a => a.IsDeleted == false).Select(selector).ToList();
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> Predicate)
        {
               return _dbcontext.Set<TEntity>().Where(a=>a.IsDeleted == false).Where(Predicate).ToList();
        }
       

        // GetById
        public TEntity? GetById(int id) => _dbcontext.Set<TEntity>().Find(id);
        // Add   
        public int Insert(TEntity entity)
        {
            _dbcontext.Set<TEntity>().Add(entity);
            return _dbcontext.SaveChanges();
        }
        // Update
        public void Update(TEntity entity)
        {
            _dbcontext.Set<TEntity>().Update(entity);
        }
        //  Delete
        public void Delete(TEntity entity)
        {
            _dbcontext.Set<TEntity>().Remove(entity);
        }

        
    }
}
