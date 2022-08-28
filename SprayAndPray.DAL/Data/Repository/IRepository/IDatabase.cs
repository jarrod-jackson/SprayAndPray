using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprayAndPray.DAL.Data.Repository.IRepository
{
    public interface IDatabase
    {
        ICustomerRepository Customer { get; }

        IPricingRepository Pricing { get; }

        IServicesRepository Services { get; }

        void Save();
    }
}
