using Microsoft.AspNetCore.Mvc;
using SprayAndPray.Business.PricingServices;
using SprayAndPray.Models;
using SprayAndPrayWeb.Constants;

namespace SprayAndPrayWeb.Areas.General.Controllers
{
    [Area("Admin")]
    public class PricingController : Controller
    {
        private readonly IPricingManager _pricingManager;

        /// <summary>
        ///     Designated Constructor
        /// </summary>
        /// <param name="pricingManager">pricing manager class</param>
        public PricingController(
            IPricingManager pricingManager)
        {
            _pricingManager = pricingManager;
        }

        /// <summary>
        ///     Get pricing index
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var pricingList = _pricingManager.GetPrices();

            return View(pricingList);
        }

        /// <summary>
        ///     Get Create Pricing
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        ///     Post Create Pricing
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pricing pricing)
        {
            if (ModelState.IsValid)
            {
                _pricingManager.Save(pricing);
                TempData["success"] = Messages.CreatePricingSuccess;

                return RedirectToAction("Index");
            }

            return View(pricing);
        }

        /// <summary>
        ///     Get Edit Pricing
        /// </summary>
        /// <returns></returns>
        public IActionResult Edit(int? id)
        {
            var pricing = _pricingManager.GetPriceById(id);

            var hasValidPricingOrId = _pricingManager.ValidatePricingUpdate(pricing, id);

            if (!hasValidPricingOrId)
            {
                return NotFound();
            }

            return View(pricing);
        }

        /// <summary>
        ///     Post - Edit Pricing Page
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Pricing pricing)
        {
            if (ModelState.IsValid)
            {
                _pricingManager.UpdatePricingInput(pricing);
                TempData["success"] = Messages.EditPricingSuccess;

                return RedirectToAction("Index");
            }

            return View(pricing);
        }

        /// <summary>
        ///     Get Delete Pricing
        /// </summary>
        /// <returns></returns>
        public IActionResult Delete(int? id)
        {
            var pricing = _pricingManager.GetPriceById(id);

            var hasValidPricingOrId = _pricingManager.ValidatePricingUpdate(pricing, id);

            if (!hasValidPricingOrId)
            {
                return NotFound();
            }

            return View(pricing);
        }

        /// <summary>
        ///     Post - Delete Pricing
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCustomer(int? id)
        {
            var price = _pricingManager.GetPriceById(id);

            if (price == null)
            {
                return NotFound();
            }

            _pricingManager.DeletePrice(price);
            TempData["success"] = Messages.DeletePricingSuccess;

            return RedirectToAction("Index");
        }
    }
}
