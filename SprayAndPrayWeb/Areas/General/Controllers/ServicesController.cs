using Microsoft.AspNetCore.Mvc;
using SprayAndPray.Business.ServicesProvidedServices;
using SprayAndPray.Models;
using SprayAndPrayWeb.Constants;

namespace SprayAndPrayWeb.Areas.General.Controllers
{
    [Area("General")]
    public class ServicesController : Controller
    {
        #region Private Variables
        /// <summary>
        ///     Service Manager
        /// </summary>
        private readonly IServicesManager _servicesManager;

        /// <summary>
        ///     Web host environment used for images
        /// </summary>
        private readonly IWebHostEnvironment _hostEnvironment;

        #endregion Private Variables


        /// <summary>
        ///     Designated Constructor
        /// </summary>
        /// <param name="servicesManager">services manager class</param>
        /// <param name="hostEnvironment">web host environment</param>
        public ServicesController(
            IServicesManager servicesManager,
            IWebHostEnvironment hostEnvironment)
        {
            _servicesManager = servicesManager;
            _hostEnvironment = hostEnvironment;
        }

        /// <summary>
        ///     Get services index
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var servicesList = _servicesManager.GetServices();

            return View(servicesList);
        }

        /// <summary>
        ///     Get Create Service
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        ///     Post Create Service
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Services service)
        {
            if (ModelState.IsValid)
            {
                _servicesManager.SaveServiceInput(service);
                TempData["success"] = Messages.CreateServiceSuccess;

                return RedirectToAction("Index");
            }

            return View(service);
        }

        /// <summary>
        ///     Get Edit Service
        /// </summary>
        /// <returns></returns>
        public IActionResult Edit(int? id)
        {
            var service = _servicesManager.GetServiceById(id);

            var hasValidServiceOrId = _servicesManager.ValidateServicesUpdate(service, id);

            if (!hasValidServiceOrId)
            {
                return NotFound();
            }

            return View(service);
        }

        /// <summary>
        ///     Post - Edit Service Page
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Services service)
        {
            if (ModelState.IsValid)
            {
                _servicesManager.UpdateServiceInput(service);
                TempData["success"] = Messages.EditServiceSuccess;

                return RedirectToAction("Index");
            }

            return View(service);
        }

        /// <summary>
        ///     Get Delete Service
        /// </summary>
        /// <returns></returns>
        public IActionResult Delete(int? id)
        {
            var service = _servicesManager.GetServiceById(id);

            var hasValidServiceOrId = _servicesManager.ValidateServicesUpdate(service, id);

            if (!hasValidServiceOrId)
            {
                return NotFound();
            }

            return View(service);
        }

        /// <summary>
        ///     Post - Delete Service
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteService(int? id)
        {
            var service = _servicesManager.GetServiceById(id);

            if (service == null)
            {
                return NotFound();
            }

            _servicesManager.DeleteService(service);
            TempData["success"] = Messages.DeleteServiceSuccess;

            return RedirectToAction("Index");
        }
    }
}
