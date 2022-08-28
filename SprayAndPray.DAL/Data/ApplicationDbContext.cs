using Microsoft.EntityFrameworkCore;
using SprayAndPray.Models;

namespace SprayAndPray.DAL
{
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        ///     Designated Constructor
        /// </summary>
        /// <param name="options">options to pass to base DbContext class</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            // Chill
        }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<Services> Services { get; set; }

        public DbSet<Pricing> Pricing { get; set; }
    }
}
