using BugsManager.Contexts;
using BugsManager.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace BugsManager.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected DatabaseContext _databaseContext;
        public RepositoryBase(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges ?
              _databaseContext.Set<T>()
                .AsNoTracking() :
              _databaseContext.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
            !trackChanges ?
              _databaseContext.Set<T>()
                .Where(expression)
                .AsNoTracking() :
              _databaseContext.Set<T>()
                .Where(expression);

        public void Create(T entity) => _databaseContext.Set<T>().Add(entity);

        public void Update(T entity) => _databaseContext.Set<T>().Update(entity);

        public void Delete(T entity) => _databaseContext.Set<T>().Remove(entity);
    }
}
