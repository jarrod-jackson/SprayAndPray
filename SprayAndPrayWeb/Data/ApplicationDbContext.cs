using Microsoft.EntityFrameworkCore;
using SprayAndPrayWeb.Models;

namespace SprayAndPrayWeb.Data
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

        public DbSet<Category> Categories { get; set; }
    }
}
