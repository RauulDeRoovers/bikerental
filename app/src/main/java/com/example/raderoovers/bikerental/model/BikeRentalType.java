package com.example.raderoovers.bikerental.model;

import com.example.raderoovers.bikerental.contract.IPriceStrategy;

/**
 * Created by Raúl A. De Roovers on 11/3/2018.
 */

enum BikeRentalType {
    HOUR(1,5),
    DAY(24, 20),
    WEEK(168, 60),
    GROUP_OF_THREE_BY_HOUR(HOUR, 3, 30),
    GROUP_OF_FOUR_BY_HOUR(HOUR, 4, 30),
    GROUP_OF_FIVE_BY_HOUR(HOUR, 5, 30),
    GROUP_OF_THREE_BY_DAY(DAY, 3, 30),
    GROUP_OF_FOUR_BY_DAY(DAY, 4, 30),
    GROUP_OF_FIVE_BY_DAY(DAY, 5, 30),
    GROUP_OF_THREE_BY_WEEK(WEEK, 3, 30),
    GROUP_OF_FOUR_BY_WEEK(WEEK, 4, 30),
    GROUP_OF_FIVE_BY_WEEK(WEEK, 5, 30),
    HALF_DAY(12, 15, false);

    private boolean isEnabled;
    private int bikesAmount;
    private int hours;
    private int discount;
    private double price;
    private IPriceStrategy priceStrategy;

    BikeRentalType(int hours, double price) {
        this(hours, price, true);
    }

    BikeRentalType(int hours, double price, boolean isEnabled) {
        this.isEnabled = isEnabled;
        this.bikesAmount = 1;
        this.hours = hours;
        this.discount = 0;
        this.price = price;
        this.priceStrategy = new DefaultPriceStrategy(this);
    }

    BikeRentalType(BikeRentalType bikeRentalType, int bikesAmount, int discount) {
        this(bikeRentalType.getHours(), bikeRentalType.getPrice());
        this.bikesAmount = bikesAmount;
        this.discount = discount;
        this.priceStrategy = new DiscountPriceStrategy(this);
    }

    public boolean isEnabled() {
        return isEnabled;
    }

    public int getHours() {
        return this.hours;
    }

    public int getDiscount() {
        return this.discount;
    }

    public int getBikesAmount() {
        return this.bikesAmount;
    }

    public double getPrice() {
        return this.price;
    }

    public double calculatePrice() {
        return this.priceStrategy.calculatePrice();
    }
}
