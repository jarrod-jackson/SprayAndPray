using SprayAndPrayWeb.Models;

namespace SprayAndPrayWeb.Business
{
    public interface ICustomerHandler
    {
        /// <summary>
        ///     Validates id and customer DTO from user input during Edit Customer
        /// </summary>
        /// <param name="customer">customer dto</param>
        /// <param name="id">customer id</param>
        /// <returns></returns>
        bool ValidateCustomerUpdate(Customer? customer, int? id);
    }
}