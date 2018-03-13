using BikeRental.Contract;
using System;

namespace BikeRental.Model
{
    public class DiscountPriceStrategy : IPriceStrategy
    {
        private int Discount { get; set; }

        public DiscountPriceStrategy(int discount)
        {
            if (discount < 1 || discount > 99)
                throw new ArgumentException("Discount should be between 1 and 99.");

            this.Discount = discount;
        }

        public double CalculatePrice(IBikeRental bikeRental)
        {
            double discountPerc = (double)(100 - this.Discount) / 100;
            double totalPrice = bikeRental.BikesAmount * bikeRental.UnitPrice * discountPerc;
            return totalPrice;
        }
    }
}
