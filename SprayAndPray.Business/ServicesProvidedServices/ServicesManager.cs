using SprayAndPray.DAL.Data.Repository.IRepository;
using SprayAndPray.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprayAndPray.Business.ServicesProvidedServices
{
    public class ServicesManager : IServicesManager
    {
        /// <summary>
        ///     Global Unit of Work
        /// </summary>
        private readonly IDatabase _database;

        /// <summary>
        ///     Designated Constructor
        /// </summary>
        /// <param name="database">global unit of work</param>
        public ServicesManager(
            IDatabase database)
        {
            _database = database;
        }

        #region Public Methods

        public bool ValidateServicesUpdate(
            Services? service,
            int? id)
        {
            return id != null && id != 0 && service != null;
        }

        #endregion Public Methods

        #region Data Methods
        public void SaveServiceInput(Services service)
        {
            _database.Services.Add(service);
            _database.Save();
        }

        public void UpdateServiceInput(Services service)
        {
            _database.Services.Update(service);
            _database.Save();
        }

        public void DeleteService(Services service)
        {
            _database.Services.Remove(service);
            _database.Save();
        }

        public Services GetServiceById(int? id)
        {
            return _database.Services.GetFirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Services> GetServices()
        {
            return _database.Services.GetAll();
        }

        #endregion Data Methods
    }
}
