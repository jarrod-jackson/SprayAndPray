using SprayAndPrayWeb.Data;
using SprayAndPrayWeb.Models;

namespace SprayAndPrayWeb.Business
{
    /// <summary>
    ///     Manager for Customer add/edit/delete
    /// </summary>
    public class CustomerManager : ICustomerManager
    {
        /// <summary>
        ///     Application DB Context
        /// </summary>
        private readonly ApplicationDbContext _dbContext;

        /// <summary>
        ///     Designated Constructor
        /// </summary>
        /// <param name="dbContext">The db context</param>
        public CustomerManager(
            ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SaveCustomerInput(Customer customer)
        {
            _dbContext.Customer.Add(customer);
            _dbContext.SaveChanges();
        }

        public void UpdateCustomerInput(Customer customer)
        {
            _dbContext.Customer.Update(customer);
            _dbContext.SaveChanges();
        }

        public void DeleteCustomer(Customer customer)
        {
            _dbContext.Customer.Remove(customer);
            _dbContext.SaveChanges();
        }
    }
}