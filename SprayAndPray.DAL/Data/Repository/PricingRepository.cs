using SprayAndPray.DAL.Data.Repository.IRepository;
using SprayAndPray.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprayAndPray.DAL.Data.Repository
{
    public class PricingRepository : Repository<Pricing>, IPricingRepository
    {
        /// <summary>
        ///     Application DB Context
        /// </summary>
        private readonly ApplicationDbContext _dbContext;

        /// <summary>
        ///     Designated Constructor
        /// </summary>
        /// <param name="dbContext"></param>
        public PricingRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(Pricing pricing)
        {
            _dbContext.Update(pricing);
        }
    }
}
