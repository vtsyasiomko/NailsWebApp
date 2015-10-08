using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NailsWebApp.Data.Common
{
    public class GenericPortalContext
    {
        private readonly DbContext _context;

        public GenericPortalContext(DbContext context)
        {
            this._context = context;
        }

        public virtual IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return _context.Set<TEntity>();
        }

        public IEnumerable<TEntity> StortedProcedure<TEntity>(string query, params object[] parameters)
        {

            return _context.Database.SqlQuery<TEntity>(query, parameters).ToList();
        }

        public void ExecuteWithStoreProcedure(string query, params object[] parameters)
        {
            _context.Database.ExecuteSqlCommand(query, parameters);
        }

        public int ExecuteStoreProcedureWithUpdateResult(string query, params object[] parameters)
        {
            return _context.Database.ExecuteSqlCommand(query, parameters);
        }

        public async Task ExecuteWithStoreProcedureAsync(string query, params object[] parameters)
        {
            await _context.Database.ExecuteSqlCommandAsync(query, parameters);
        }

        public T ExecuteFunctionScalar<T>(string query, params object[] parameters)
        {
            return _context.Database.SqlQuery<T>(query, parameters).Single();
        }

        public IEnumerable<T> ExecuteTableFunction<T>(string query, params object[] parameters)
        {
            return _context.Database.SqlQuery<T>(query, parameters).ToList();
        }

        public DbContextTransaction DbTransaction { set; get; }

        public void Commit()
        {
            DbTransaction.Commit();
        }

        public void Rollback()
        {
            DbTransaction.Rollback();
        }

        public void BeginTransaction()
        {
            DbTransaction = _context.Database.BeginTransaction();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
