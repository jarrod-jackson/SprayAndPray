using SprayAndPray.Models;

namespace SprayAndPray.Business.PricingServices
{
    public interface IPricingManager
    {
        bool ValidatePricingUpdate(Pricing? price, int? id);

        #region Data Methods

        /// <summary>
        ///     Saves user input from Pricing page to DB
        /// </summary>
        /// <param name="pricing">Pricing Dto</param>
        public void Save(Pricing price);

        /// <summary>
        ///     Updates user input from Pricing Edit page to DB
        /// </summary>
        /// <param name="price">Pricing Dto</param>
        public void UpdatePricingInput(Pricing price);

        /// <summary>
        ///     Deletes the Price from the DB
        /// </summary>
        /// <param name="price">Pricing Dto</param>
        public void DeletePrice(Pricing price);

        /// <summary>
        ///     Gets first or default price by ID
        /// </summary>
        /// <param name="id">price ID</param>
        /// <returns>Pricing Dto</returns>
        public Pricing GetPriceById(int? id);

        /// <summary>
        ///     Get all prices
        /// </summary>
        /// <returns>IEnumerable of Pricing</returns>
        public IEnumerable<Pricing> GetPrices();

        #endregion Data Methods
    }
}
