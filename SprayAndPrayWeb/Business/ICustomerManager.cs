using SprayAndPrayWeb.Models;

namespace SprayAndPrayWeb.Business
{
    public interface ICustomerManager
    {
        public void SaveCustomerInput(Customer customer);
    }
}