using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace NailsApp.Data.Common
{
    public interface IRepository<TEntity, TContext> : IDisposable
        where TEntity : class
        where TContext : IDbContext
    {
        void Delete(TEntity entity);

        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter);

        TEntity Find(params object[] keyValues);

        TEntity Insert(TEntity entity);

        void InsertRange(IEnumerable<TEntity> entities, int batchSize);

        /// <summary>
        /// If true changes are saved after each modificaiton set
        /// </summary>
        bool AutoCommitEnabled { get; set; }

        void SaveChanges();

        void ExecuteWithStoreProcedure(string query, params object[] parameters);

        int ExecuteStoreProcedureWithUpdateResult(string query, params object[] parameters);

        IEnumerable<TEntity> StortedProcedure(string query, params object[] parameters);

        T ExecuteFunctionScalar<T>(string query, params object[] parameters);

        IEnumerable<T> ExecuteTableFunction<T>(string query, params object[] parameters);

        DbContextTransaction DbTransaction { get; set; }

        void Commit();

        void Rollback();

        void BeginTransaction();
    }
}