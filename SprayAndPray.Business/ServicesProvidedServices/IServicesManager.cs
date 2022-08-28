using SprayAndPray.Models;

namespace SprayAndPray.Business.ServicesProvidedServices
{
    public interface IServicesManager
    {
        bool ValidateServicesUpdate(Services? service, int? id);

        #region Data Methods

        /// <summary>
        ///     Saves user input from Services page to DB
        /// </summary>
        /// <param name="service">Services Dto</param>
        public void SaveServiceInput(Services service);

        /// <summary>
        ///     Updates user input from Services Edit page to DB
        /// </summary>
        /// <param name="service">Services Dto</param>
        public void UpdateServiceInput(Services service);

        /// <summary>
        ///     Deletes the Services from the DB
        /// </summary>
        /// <param name="service">Services Dto</param>
        public void DeleteService(Services service);

        /// <summary>
        ///     Gets first or default service by ID
        /// </summary>
        /// <param name="id">service ID</param>
        /// <returns>Services Dto</returns>
        public Services GetServiceById(int? id);

        /// <summary>
        ///     Get all services
        /// </summary>
        /// <returns>IEnumerable of Services</returns>
        public IEnumerable<Services> GetServices();

        #endregion Data Methods
    }
}
