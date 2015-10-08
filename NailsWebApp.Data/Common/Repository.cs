using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NailsWebApp.Data.Common
{
    public class Repository<TEntity, TContext> : IRepository<TEntity, TContext>
        where TEntity : class
        where TContext : IDbContext
    {
        private readonly IDbContext _context;

        public Repository(TContext context)
        {
            this._context = context;
            this.AutoCommitEnabled = true;
            this.DbTransaction = context.DbTransaction;
        }

        /// <summary>
        /// If true changes are saved after each modificaiton set
        /// </summary>
        public bool AutoCommitEnabled { get; set; }

        public IQueryable<TEntity> GetAll()
        {
            return GetEntities().AsQueryable();
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter)
        {
            return GetEntities().Where(filter);
        }

        public TEntity Insert(TEntity entity)
        {
            return GetEntities().Add(entity);
        }

        public void InsertRange(IEnumerable<TEntity> entities, int batchSize = 100)
        {
            //throw new NotSupportedException("Please do refactor this before using, Batch seem to be illogical at all.");
            try
            {
                if (GetEntities() == null)
                {
                    throw new ArgumentNullException("entities");
                }

                IEnumerable<TEntity> entitiesList = entities as IList<TEntity> ?? entities.ToList();
                if (!entitiesList.Any())
                {
                    return;
                }

                if (batchSize <= 0)
                {
                    // insert all in one step
                    entitiesList.ToList().ForEach(x => this.GetEntities().Add(x));

                    if (this.AutoCommitEnabled)
                    {
                        _context.SaveChanges();
                    }
                }
                else
                {
                    int i = 1;
                    bool saved = false;
                    foreach (var entity in GetEntities())
                    {
                        this.GetEntities().Add(entity);
                        saved = false;
                        if (i % batchSize == 0)
                        {
                            if (this.AutoCommitEnabled)
                                _context.SaveChanges();
                            i = 0;
                            saved = true;
                        }
                        i++;
                    }

                    if (!saved)
                    {
                        if (this.AutoCommitEnabled)
                            _context.SaveChanges();
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }

        }

        public void Delete(TEntity entity)
        {
            GetEntities().Remove(entity);
        }

        public TEntity Find(params object[] keyValues)
        {
            return GetEntities().Find(keyValues);
        }

        public void SaveChanges()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                                                        validationErrors.Entry.Entity,
                                                        validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }

                throw raise;
            }
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }


        public void ExecuteWithStoreProcedure(string query, params object[] parameters)
        {
            _context.ExecuteWithStoreProcedure(query, parameters);
        }

        public int ExecuteStoreProcedureWithUpdateResult(string query, params object[] parameters)
        {
            return _context.ExecuteStoreProcedureWithUpdateResult(query, parameters);
        }

        public IEnumerable<TEntity> StortedProcedure(string query, params object[] parameters)
        {
            return _context.StortedProcedure<TEntity>(query, parameters);
        }

        public T ExecuteFunctionScalar<T>(string query, params object[] parameters)
        {
            return _context.ExecuteFunctionScalar<T>(query, parameters);
        }

        public IEnumerable<T> ExecuteTableFunction<T>(string query, params object[] parameters)
        {
            return _context.ExecuteTableFunction<T>(query, parameters);
        }

        public DbContextTransaction DbTransaction { get; set; }

        public void Commit()
        {
            _context.Commit();
        }

        public void Rollback()
        {
            _context.Rollback();
        }

        public void BeginTransaction()
        {
            _context.BeginTransaction();
        }

        #region Private 

        private IDbSet<TEntity> GetEntities()
        {
            return _context.Set<TEntity>();
        }
        #endregion
    }
}
