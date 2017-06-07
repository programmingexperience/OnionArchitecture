using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using OA.Data.Model;
using OA.Repo.Repository;

namespace OA.Repo.UoW
{
    public class GenericUoW : IGenericUoW, IDisposable
    {
        private readonly OnionArchitectureEntities _context;
        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();
        private DbContextTransaction _transaction;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        public GenericUoW()
        {
            this._context = new OnionArchitectureEntities();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IGenericRepository<T> GenericRepository<T>() where T : class
        {
            if (repositories.Keys.Contains(typeof(T)) == true)
            {
                return repositories[typeof(T)] as IGenericRepository<T>;
            }
            IGenericRepository<T> repo = new GenericRepository<T>(_context);
            repositories.Add(typeof(T), repo);
            return repo;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DbContextTransaction BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
            return _transaction;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Int64 SaveChanges()
        {
            return _context.SaveChanges();
        }
        /// <summary>
        /// IDisposable implementation
        /// </summary>
        private bool disposed = false;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
