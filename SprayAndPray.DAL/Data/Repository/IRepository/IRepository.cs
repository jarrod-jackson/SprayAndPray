using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SprayAndPray.DAL.Data.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        ///     User linq expression to get first or default record from DB
        ///     Requires generic type input and will have bool output
        ///     Have to pass in a filter to query against
        /// </summary>
        /// <param name="filter">filter for expression to query against</param>
        /// <returns></returns>
        T GetFirstOrDefault(Expression<Func<T, bool>> filter);

        /// <summary>
        ///     Get all records from table
        /// </summary>
        /// <returns>IEnumaerable of generic type</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        ///     Add record
        /// </summary>
        /// <param name="entity">generic entity</param>
        void Add(T entity);

        /// <summary>
        ///     Remove record
        /// </summary>
        /// <param name="entity">generic entity</param>
        void Remove(T entity);

        /// <summary>
        ///     Remove multiple records
        /// </summary>
        /// <param name="entity">IEnumaerable of generic type</param>
        void RemoveRange(IEnumerable<T> entity);
    }
}
