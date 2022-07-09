using SprayAndPray.DAL.Data.Repository.IRepository;
using SprayAndPray.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprayAndPray.DAL.Data.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        /// <summary>
        ///     Application DB Context
        /// </summary>
        private ApplicationDbContext _dbContext;

        /// <summary>
        ///     Designated Constructor
        /// </summary>
        /// <param name="dbContext"></param>
        public CustomerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(Customer customer)
        {
            _dbContext.Update(customer);
        }
    }
}
