namespace BikeRental.Contract
{
    public interface IPriceStrategy
    {
        double CalculatePrice(IBikeRental bikeRental);
    }
}
