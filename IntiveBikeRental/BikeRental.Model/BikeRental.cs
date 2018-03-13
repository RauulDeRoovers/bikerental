using BikeRental.Contract;

namespace BikeRental.Model
{
    public class BikeRental : IBikeRental
    {
        public int LengthInHours
        {
            get;
            private set;
        }

        public int UnitPrice
        {
            get;
            private set;
        }

        public int BikesAmount
        {
            get;
            private set;
        }

        public string Name
        {
            get;
            private set;
        }

        public double TotalPrice
        {
            get { return this.PriceStrategy.CalculatePrice(this); }
        }

        private IPriceStrategy PriceStrategy { get; set; }

        public BikeRental(string name, int lengthInOurs, int unitPrice, int bikesAmount, IPriceStrategy priceStrategy)
        {
            this.Name = name;
            this.LengthInHours = lengthInOurs;
            this.UnitPrice = unitPrice;
            this.BikesAmount = bikesAmount;
            this.PriceStrategy = priceStrategy;
        }
    }
}
