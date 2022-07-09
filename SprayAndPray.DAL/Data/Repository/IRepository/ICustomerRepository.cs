using SprayAndPray.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprayAndPray.DAL.Data.Repository.IRepository
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        /// <summary>
        ///     Update Customer record
        /// </summary>
        /// <param name="customer">customer dto</param>
        void Update(Customer customer);
    }
}
