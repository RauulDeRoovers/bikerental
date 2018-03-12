package com.example.raderoovers.bikerental.model;

import com.example.raderoovers.bikerental.contract.IRental;

/**
 * Created by Raúl A. De Roovers on 11/3/2018.
 */

public class BikeRental implements IRental {

    private int hours;
    private double price;

    BikeRental(BikeRentalType bikeRentalType) {
        this.hours = bikeRentalType.getHours();
        this.price = bikeRentalType.calculatePrice();
    }

    @Override
    public int getHours() {
        return this.hours;
    }

    @Override
    public double getPrice() {
        return this.price;
    }

}
