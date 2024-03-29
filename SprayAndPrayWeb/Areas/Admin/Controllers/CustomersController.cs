﻿using Microsoft.AspNetCore.Mvc;
using SprayAndPray.Business.CustomerServices;
using SprayAndPray.Models;
using SprayAndPrayWeb.Constants;

namespace SprayAndPrayWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomersController : Controller
    {
        #region Private Variables
        /// <summary>
        ///     Customer Manager Service
        /// </summary>
        private readonly ICustomerManager _customerManager;

        #endregion Private Variables


        /// <summary>
        ///     Designated Constructor
        /// </summary>
        /// <param name="customerManager">customer manager class</param>
        public CustomersController(
            ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }

        /// <summary>
        ///     Get customer index
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var customerList = _customerManager.GetCustomers();

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
            var customer = _customerManager.GetCustomerById(id);

            var hasValidCustomerOrId = _customerManager.ValidateCustomerUpdate(customer, id);

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
        ///     Get Delete Customer
        /// </summary>
        /// <returns></returns>
        public IActionResult Delete(int? id)
        {
            var customer = _customerManager.GetCustomerById(id);

            var hasValidCustomerOrId = _customerManager.ValidateCustomerUpdate(customer, id);

            if (!hasValidCustomerOrId)
            {
                return NotFound();
            }

            return View(customer);
        }

        /// <summary>
        ///     Post - Delete Customer
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCustomer(int? id)
        {
            var customer = _customerManager.GetCustomerById(id);

            if (customer == null)
            {
                return NotFound();
            }

            _customerManager.DeleteCustomer(customer);
            TempData["success"] = Messages.DeleteCustomerSuccess;

            return RedirectToAction("Index");
        }
    }
}