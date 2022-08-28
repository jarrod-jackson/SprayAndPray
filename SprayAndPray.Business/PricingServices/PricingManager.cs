using SprayAndPray.DAL.Data.Repository.IRepository;
using SprayAndPray.Models;

namespace SprayAndPray.Business.PricingServices
{
    public class PricingManager : IPricingManager
    {
        /// <summary>
        ///     Global Unit of Work
        /// </summary>
        private readonly IDatabase _database;

        /// <summary>
        ///     Designated Constructor
        /// </summary>
        /// <param name="database">global unit of work</param>
        public PricingManager(
            IDatabase database)
        {
            _database = database;
        }

        #region Public Methods

        public bool ValidatePricingUpdate(
            Pricing? pricing,
            int? id)
        {
            return id != null && id != 0 && pricing != null;
        }

        #endregion Public Methods

        #region Data Methods
        public void Save(Pricing price)
        {
            _database.Pricing.Add(price);
            _database.Save();
        }

        public void UpdatePricingInput(Pricing price)
        {
            _database.Pricing.Update(price);
            _database.Save();
        }

        public void DeletePrice(Pricing price)
        {
            _database.Pricing.Remove(price);
            _database.Save();
        }

        public Pricing GetPriceById(int? id)
        {
            return _database.Pricing.GetFirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Pricing> GetPrices()
        {
            return _database.Pricing.GetAll();
        }

        #endregion Data Methods
    }
}
