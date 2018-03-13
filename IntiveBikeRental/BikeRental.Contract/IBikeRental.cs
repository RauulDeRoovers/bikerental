namespace BikeRental.Contract
{
    public interface IBikeRental
    {
        int LengthInHours { get; }
        int UnitPrice { get; }
        int BikesAmount { get; }
        string Name { get; }
        double TotalPrice { get;  }
    }
}
