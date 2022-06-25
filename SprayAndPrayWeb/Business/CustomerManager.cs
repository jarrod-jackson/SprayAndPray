using SprayAndPrayWeb.Data;
using SprayAndPrayWeb.Models;

namespace SprayAndPrayWeb.Business
{
    public class CustomerManager : ICustomerManager
    {
        private readonly ApplicationDbContext _dbContext;

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
    }
}
