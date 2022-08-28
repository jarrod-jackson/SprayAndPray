using SprayAndPray.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprayAndPray.DAL.Data.Repository.IRepository
{
    public interface IPricingRepository : IRepository<Pricing>
    {
        /// <summary>
        ///     Update Pricing record
        /// </summary>
        /// <param name="pricing">customer dto</param>
        void Update(Pricing pricing);
    }
}
