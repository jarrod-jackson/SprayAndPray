using SprayAndPray.Models;

namespace SprayAndPray.Business
{
    public interface ICustomerHandler
    {
        /// <summary>
        ///     Validates id and customer DTO from user input during Edit Customer
        /// </summary>
        /// <param name="customer">customer dto</param>
        /// <param name="id">customer id</param>
        /// <returns>true if Customer is not null and ID is not null or 0</returns>
        bool ValidateCustomerUpdate(Customer? customer, int? id);
    }
}