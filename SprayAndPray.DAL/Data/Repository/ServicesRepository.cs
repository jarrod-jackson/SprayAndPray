using SprayAndPray.DAL.Data.Repository.IRepository;
using SprayAndPray.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprayAndPray.DAL.Data.Repository
{
    public class ServicesRepository : Repository<Services>, IServicesRepository
    {
        /// <summary>
        ///     Application DB Context
        /// </summary>
        private readonly ApplicationDbContext _dbContext;

        /// <summary>
        ///     Designated Constructor
        /// </summary>
        /// <param name="dbContext"></param>
        public ServicesRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(Services service)
        {
            var dbServiceObject = _dbContext.Services.FirstOrDefault(s => s.Id == service.Id);

            if (dbServiceObject != null)
            {
                dbServiceObject.Id = service.Id;
                dbServiceObject.Name = service.Name;
                dbServiceObject.Description = service.Description;

                if(dbServiceObject.ImageUrl != null)
                {
                    dbServiceObject.ImageUrl = service.ImageUrl;
                }
            }
        }
    }
}
