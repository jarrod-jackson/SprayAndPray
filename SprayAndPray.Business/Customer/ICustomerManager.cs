using SprayAndPray.Models;

namespace SprayAndPray.Business
{
    public interface ICustomerManager
    {
        /// <summary>
        ///     Saves user input from Customers page to DB
        /// </summary>
        /// <param name="customer">Customer Dto</param>
        public void SaveCustomerInput(Customer customer);

        /// <summary>
        ///     Updates user input from Customers Edit page to DB
        /// </summary>
        /// <param name="customer">Customer Dto</param>
        public void UpdateCustomerInput(Customer customer);

        /// <summary>
        ///     Deletes the Customer from the DB
        /// </summary>
        /// <param name="customer">Customer Dto</param>
        public void DeleteCustomer(Customer customer);

        /// <summary>
        ///     Gets first or default customer by ID
        /// </summary>
        /// <param name="id">customer ID</param>
        /// <returns>Customer Dto</returns>
        public Customer GetCustomerById(int? id);

        /// <summary>
        ///     Get all customers
        /// </summary>
        /// <returns>IEnumerable of Customers</returns>
        public IEnumerable<Customer> GetCustomers();
    }
}