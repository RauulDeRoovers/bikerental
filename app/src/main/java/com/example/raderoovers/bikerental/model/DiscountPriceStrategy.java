package com.example.raderoovers.bikerental.model;

/**
 * Created by Raúl A. De Roovers on 11/3/2018.
 */

class DiscountPriceStrategy extends BasePriceStrategy {

    DiscountPriceStrategy(BikeRentalType bikeRentalType) {
        super(bikeRentalType);
    }

    @Override
    public double calculatePrice() {
        double basePrice = this.bikeRentalType.getPrice() * this.bikeRentalType.getBikesAmount();
        double discountPercentage = (double)(100 - this.bikeRentalType.getDiscount()) / 100;
        return basePrice * discountPercentage;
    }
}
