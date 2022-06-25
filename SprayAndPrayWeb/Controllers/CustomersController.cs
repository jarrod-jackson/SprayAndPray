using Microsoft.AspNetCore.Mvc;
using SprayAndPrayWeb.Business;
using SprayAndPrayWeb.Data;
using SprayAndPrayWeb.Models;

namespace SprayAndPrayWeb.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IConfiguration _configuration;
        private readonly ICustomerManager _customerManager;

        /// <summary>
        ///     Designated Constructor
        /// </summary>
        /// <param name="dbContext">db context</param>
        /// <param name="configuration">configuration</param>
        public CustomersController(
            ApplicationDbContext dbContext,
            IConfiguration configuration,
            ICustomerManager customerManager)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _customerManager = customerManager;
        }

        /// <summary>
        ///     Get customer index
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var customerList = _dbContext.Customer.AsEnumerable();

            return View(customerList);
        }

        /// <summary>
        ///     Get Create Customer
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        ///     Post Create Customer
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Customer customer)
        {
            if(ModelState.IsValid)
            {
                _customerManager.SaveCustomerInput(customer);

                return RedirectToAction("Index");
            }
            return View(customer);
            
        }
    }
}
