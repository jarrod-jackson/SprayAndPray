using SprayAndPray.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprayAndPray.DAL.Data.Repository.IRepository
{
    public interface IServicesRepository : IRepository<Services>
    {
        /// <summary>
        ///     Update Services record
        /// </summary>
        /// <param name="services">customer dto</param>
        void Update(Services services);
    }
}
