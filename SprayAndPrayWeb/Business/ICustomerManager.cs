using SprayAndPrayWeb.Models;

namespace SprayAndPrayWeb.Business
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
    }
}