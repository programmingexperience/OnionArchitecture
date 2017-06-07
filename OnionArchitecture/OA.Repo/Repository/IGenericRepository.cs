using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace OA.Repo.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Get all entities from db
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        List<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            params Expression<Func<T, object>>[] includes);
        /// <summary>
        /// Get query for entity
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        IQueryable<T> Query(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>,
            IOrderedQueryable<T>> orderBy = null);
        /// <summary>
        /// Get single entity by primary key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetById(object id);
        /// <summary>
        /// Get first or default entity by filter
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        T GetFirstOrDefault(
            Expression<Func<T, bool>> filter = null,
            params Expression<Func<T, object>>[] includes);
        /// <summary>
        /// Insert entity to db
        /// </summary>
        /// <param name="entity"></param>
        void Insert(T entity);
        /// <summary>
        /// Update entity in db
        /// </summary>
        /// <param name="entity"></param>
        Task Update(T entity);
        /// <summary>
        /// Delete entity from db by primary key
        /// </summary>
        /// <param name="id"></param>
        Task Delete(T entity);
    }
}
