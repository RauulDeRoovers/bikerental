namespace BikeRental.Contract
{
    public interface IBikeRentalFactory
    {
        IBikeRental GetRentalByName(string rentalName);
        IBikeRental GetHourRental();
        IBikeRental GetDayRental();
        IBikeRental GetWeekRental();
        IBikeRental GeFamilyHourRentalForThree();
        IBikeRental GeFamilyDayRentalForThree();
        IBikeRental GeFamilyWeekRentalForThree();
        IBikeRental GeFamilyWeekRentalForSix();
        int GetBikeRentalsCount();
    }
}
