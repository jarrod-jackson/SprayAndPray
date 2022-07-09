using Microsoft.EntityFrameworkCore;
using SprayAndPray.DAL.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SprayAndPray.DAL.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        /// <summary>
        ///     Application DB Context
        /// </summary>
        private readonly ApplicationDbContext _dbContext;

        /// <summary>
        ///     DB Set
        /// </summary>
        internal DbSet<T> dbSet;

        /// <summary>
        ///     Designated Constructor
        /// </summary>
        /// <param name="dbContext">db context</param>
        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            this.dbSet = _dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;

            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;

            query = query.Where(filter);

            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
    }
}
