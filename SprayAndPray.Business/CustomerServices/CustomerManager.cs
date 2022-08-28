using SprayAndPray.Business.CustomerServices;
using SprayAndPray.DAL.Data.Repository.IRepository;
using SprayAndPray.Models;

namespace SprayAndPray.Business
{
    /// <summary>
    ///     Manager for Customer add/edit/delete
    /// </summary>
    public class CustomerManager : ICustomerManager
    {
        /// <summary>
        ///     Global Unit of Work
        /// </summary>
        private readonly IDatabase _database;

        /// <summary>
        ///     Designated Constructor
        /// </summary>
        /// <param name="database">global unit of work</param>
        public CustomerManager(
            IDatabase database)
        {
            _database = database;
        }

        #region Public Methods

        public bool ValidateCustomerUpdate(
            Customer? customer,
            int? id)
        {
            return id != null && id != 0 && customer != null;
        }

        #endregion Public Methods

        #region Data Methods
        public void SaveCustomerInput(Customer customer)
        {
            _database.Customer.Add(customer);
            _database.Save();
        }

        public void UpdateCustomerInput(Customer customer)
        {
            _database.Customer.Update(customer);
            _database.Save();
        }

        public void DeleteCustomer(Customer customer)
        {
            _database.Customer.Remove(customer);
            _database.Save();
        }

        public Customer GetCustomerById(int? id)
        {
            return _database.Customer.GetFirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Customer>GetCustomers()
        {
            return _database.Customer.GetAll();
        }

        #endregion Data Methods
    }
}