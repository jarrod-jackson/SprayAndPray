using Microsoft.AspNetCore.Mvc;
using SprayAndPrayWeb.Business;
using SprayAndPrayWeb.Constants;
using SprayAndPrayWeb.Data;
using SprayAndPrayWeb.Models;

namespace SprayAndPrayWeb.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IConfiguration _configuration;
        private readonly ICustomerManager _customerManager;
        private readonly ICustomerHandler _customerHandler;

        /// <summary>
        ///     Designated Constructor
        /// </summary>
        /// <param name="dbContext">db context</param>
        /// <param name="configuration">configuration</param>
        public CustomersController(
            ApplicationDbContext dbContext,
            IConfiguration configuration,
            ICustomerManager customerManager,
            ICustomerHandler customerHandler)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _customerManager = customerManager;
            _customerHandler = customerHandler;
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
            if (ModelState.IsValid)
            {
                _customerManager.SaveCustomerInput(customer);
                TempData["success"] = Messages.CreateCustomerSuccess;

                return RedirectToAction("Index");
            }

            return View(customer);
        }

        /// <summary>
        ///     Get Edit Customer
        /// </summary>
        /// <returns></returns>
        public IActionResult Edit(int? id)
        {
            var customer = _dbContext.Customer.FirstOrDefault(x => x.Id == id);

            var hasValidCustomerOrId = _customerHandler.ValidateCustomerUpdate(customer, id);

            if (!hasValidCustomerOrId)
            {
                return NotFound();
            }

            return View(customer);
        }

        /// <summary>
        ///     Post - Edit Customer Page
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customerManager.UpdateCustomerInput(customer);
                TempData["success"] = Messages.EditCustomerSuccess;

                return RedirectToAction("Index");
            }

            return View(customer);
        }

        /// <summary>
        ///     Get Edit Customer
        /// </summary>
        /// <returns></returns>
        public IActionResult Delete(int? id)
        {
            var customer = _dbContext.Customer.FirstOrDefault(x => x.Id == id);

            var hasValidCustomerOrId =
                id != null ||
                id != 0 ||
                customer != null;

            if (!hasValidCustomerOrId)
            {
                return NotFound();
            }

            return View(customer);
        }

        /// <summary>
        ///     Post - Edit Customer Page
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCustomer(int? id)
        {
            var customer = _dbContext.Customer.FirstOrDefault(x => x.Id == id);

            if(customer == null)
            {
                return NotFound();
            }

            _customerManager.DeleteCustomer(customer);
            TempData["success"] = Messages.DeleteCustomerSuccess;

            return RedirectToAction("Index");
        }
    }
}