using BikeRental.Contract;

namespace BikeRental.Model
{
    public class DefaultPriceStrategy : IPriceStrategy
    {
        public double CalculatePrice(IBikeRental bikeRental)
        {
            return bikeRental.UnitPrice;
        }
    }
}
