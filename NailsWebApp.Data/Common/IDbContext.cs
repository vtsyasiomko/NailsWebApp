using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace NailsApp.Data.Common
{
    public interface IDbContext : IDisposable
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        int SaveChanges();

        /// <summary>
        /// Accessing sp to retrieve a list of objects
        /// </summary>
        IEnumerable<TEntity> StortedProcedure<TEntity>(string query, params object[] parameters);

        /// <summary>
        /// Execute SP without return value
        /// </summary>
        void ExecuteWithStoreProcedure(string query, params object[] parameters);

        int ExecuteStoreProcedureWithUpdateResult(string query, params object[] parameters);

        Task ExecuteWithStoreProcedureAsync(string query, params object[] parameters);

        T ExecuteFunctionScalar<T>(string query, params object[] parameters);

        IEnumerable<T> ExecuteTableFunction<T>(string query, params object[] parameters);

        DbContextTransaction DbTransaction { get; set; }

        void Commit();

        void Rollback();

        void BeginTransaction();
    }
}