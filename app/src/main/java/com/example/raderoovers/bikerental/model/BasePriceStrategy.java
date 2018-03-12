package com.example.raderoovers.bikerental.model;

import com.example.raderoovers.bikerental.contract.IPriceStrategy;

/**
 * Created by Raúl A. De Roovers on 11/3/2018.
 */

abstract class BasePriceStrategy implements IPriceStrategy {

    BikeRentalType bikeRentalType;

    BasePriceStrategy(BikeRentalType bikeRentalType) {
        this.bikeRentalType = bikeRentalType;
    }
}
