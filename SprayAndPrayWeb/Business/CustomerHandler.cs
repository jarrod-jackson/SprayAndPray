using SprayAndPrayWeb.Models;

namespace SprayAndPrayWeb.Business
{
    /// <summary>
    ///     Class to handle user i/o for Customer
    /// </summary>
    public class CustomerHandler : ICustomerHandler
    {
        public bool ValidateCustomerUpdate(
            Customer? customer,
            int? id)
        {
            return id != null || id != 0 || customer != null;
        }
    }
}
