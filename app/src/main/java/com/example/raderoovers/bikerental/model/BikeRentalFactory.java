package com.example.raderoovers.bikerental.model;

import com.example.raderoovers.bikerental.contract.IRental;

import java.util.HashMap;
import java.util.Map;

/**
 * Created by Raúl A. De Roovers on 11/3/2018.
 */

public class BikeRentalFactory {

    private Map<BikeRentalType, BikeRental> bikeRentals;

    public BikeRentalFactory() {
        bikeRentals = new HashMap<>();
        for (BikeRentalType bikeRentalType : BikeRentalType.values()) {
            if (!bikeRentalType.isEnabled())
                continue;
            BikeRental bikeRental = new BikeRental(bikeRentalType);
            bikeRentals.put(bikeRentalType, bikeRental);
        }
    }

    private IRental createBikeRental(BikeRentalType bikeRentalType) throws Exception {
        if (!bikeRentals.containsKey(bikeRentalType))
            throw new Exception(bikeRentalType + " rental is disabled.");

        return bikeRentals.get(bikeRentalType);
    }

    public IRental createHourBikeRental() throws Exception {
        return createBikeRental(BikeRentalType.HOUR);
    }

    public IRental createDayBikeRental() throws Exception {
        return createBikeRental(BikeRentalType.DAY);
    }

    public IRental createWeekBikeRental() throws Exception {
        return createBikeRental(BikeRentalType.WEEK);
    }

    public IRental createFamilyRentalByHourForThreeMembers() throws Exception {
        return createBikeRental(BikeRentalType.GROUP_OF_THREE_BY_HOUR);
    }

    public IRental createFamilyRentalByHourForFourMembers() throws Exception {
        return createBikeRental(BikeRentalType.GROUP_OF_FOUR_BY_HOUR);
    }

    public IRental createFamilyRentalByHourForFiveMembers() throws Exception {
        return createBikeRental(BikeRentalType.GROUP_OF_FIVE_BY_HOUR);
    }

    public IRental createFamilyRentalByDayForThreeMembers() throws Exception {
        return createBikeRental(BikeRentalType.GROUP_OF_THREE_BY_DAY);
    }

    public IRental createFamilyRentalByDayForFourMembers() throws Exception {
        return createBikeRental(BikeRentalType.GROUP_OF_FOUR_BY_DAY);
    }

    public IRental createFamilyRentalByDayForFiveMembers() throws Exception {
        return createBikeRental(BikeRentalType.GROUP_OF_FIVE_BY_DAY);
    }

    public IRental createFamilyRentalByWeekForThreeMembers() throws Exception {
        return createBikeRental(BikeRentalType.GROUP_OF_THREE_BY_WEEK);
    }

    public IRental createFamilyRentalByWeekForFourMembers() throws Exception {
        return createBikeRental(BikeRentalType.GROUP_OF_FOUR_BY_WEEK);
    }

    public IRental createFamilyRentalByWeekForFiveMembers() throws Exception {
        return createBikeRental(BikeRentalType.GROUP_OF_FIVE_BY_WEEK);
    }

    public IRental createHalfDayRental() throws Exception {
        return createBikeRental(BikeRentalType.HALF_DAY);
    }
}
