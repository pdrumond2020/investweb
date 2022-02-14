using Invest.Data.Context;
using Invest.Domain.Entities;
using Invest.Domain.Interfaces.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Invest.Data.Repositories.Base
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly InvestContext _context;

        protected DbSet<TEntity> DbSet => _context.Set<TEntity>();

        public RepositoryBase(InvestContext context) => this._context = context;

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> where = null)
        {
            if (where != null)
                return DbSet.Where(where);

            return DbSet.AsQueryable();
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, object> includes)
        {
            IQueryable<TEntity> _query = DbSet;

            if (includes != null)
                _query = includes(_query) as IQueryable<TEntity>;

            return _query.Where(where).AsQueryable();
        }

        public TEntity Find(Expression<Func<TEntity, bool>> where)
        {
            return DbSet.AsNoTracking().FirstOrDefault(where);
        }

        public TEntity Find(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, object> includes)
        {
            IQueryable<TEntity> _query = DbSet;

            if (includes != null)
                _query = includes(_query) as IQueryable<TEntity>;

            return _query.AsNoTracking().FirstOrDefault(predicate);
        }

        public int FindSQL(string query)
        {
            return _context.Database.ExecuteSqlInterpolated($"{query}");
        }

        public TEntity Create(TEntity model)
        {
            DbSet.Add(model);
            Save();
            return model;
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public bool Update(TEntity model)
        {
            var entry = _context.Entry(model);

            DbSet.Attach(model);

            entry.State = EntityState.Modified;

            return Save() > 0;
        }

        public bool Delete(TEntity model)
        {
            if (model is Entity)
            {
                (model as Entity).IsActive = false;
                var _entry = _context.Entry(model);

                DbSet.Attach(model);

                _entry.State = EntityState.Modified;
            }
            else
            {
                var _entry = _context.Entry(model);
                DbSet.Attach(model);
                _entry.State = EntityState.Deleted;
            }

            return Save() > 0;
        }

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.DisposeAsync();
                }

                disposedValue = true;
            }
        }

        ~RepositoryBase()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}