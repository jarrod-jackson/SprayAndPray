using SprayAndPray.DAL.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprayAndPray.DAL.Data.Repository
{
    public class Database : IDatabase
    {
        /// <summary>
        ///     Application DB Context
        /// </summary>
        private ApplicationDbContext _dbContext;

        /// <summary>
        ///     Designated Constructor
        /// </summary>
        /// <param name="dbContext">the db context</param>
        public Database(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            Customer = new CustomerRepository(_dbContext);
        }

        public ICustomerRepository Customer { get; private set; }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
