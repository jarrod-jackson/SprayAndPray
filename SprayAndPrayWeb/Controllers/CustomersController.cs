using Microsoft.AspNetCore.Mvc;
using SprayAndPrayWeb.Data;
using SprayAndPrayWeb.Models;

namespace SprayAndPrayWeb.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public CustomersController(
            ApplicationDbContext dbContext,
            IConfiguration configureation)
        {
            _dbContext = dbContext;
            _configuration = configureation;
        }
        public IActionResult Index()
        {
            var customerList = _dbContext.Customers.AsEnumerable();

            return View(customerList);
        }
    }
}
