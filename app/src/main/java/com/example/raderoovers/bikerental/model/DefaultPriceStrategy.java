package com.example.raderoovers.bikerental.model;

/**
 * Created by Raúl A. De Roovers on 11/3/2018.
 */

class DefaultPriceStrategy extends BasePriceStrategy {

    DefaultPriceStrategy(BikeRentalType bikeRentalType) {
        super(bikeRentalType);
    }

    @Override
    public double calculatePrice() {
        return bikeRentalType.getPrice();
    }
}
