package com.example.raderoovers.bikerental;

import com.example.raderoovers.bikerental.contract.IRental;
import com.example.raderoovers.bikerental.model.BikeRentalFactory;

import org.junit.Before;
import org.junit.Test;

import static junit.framework.Assert.assertEquals;
import static junit.framework.Assert.assertNotNull;
import static junit.framework.Assert.assertNull;

/**
 * Example local unit test, which will execute on the development machine (host).
 *
 * @see <a href="http://d.android.com/tools/testing">Testing documentation</a>
 */
public class BikeRentalUnitTest {

    private BikeRentalFactory validBikeRentalFactory;

    @Before
    public void initialize() {
        validBikeRentalFactory = new BikeRentalFactory();
    }

    @Test
    public void hourRental() throws Exception {
        IRental hourRental = validBikeRentalFactory.createHourBikeRental();
        assertEquals("Rental length in hours for Hour rentals should be 1.", 1, hourRental.getHours());
        assertEquals("Rental price for Hour rentals should be 5.", 5, hourRental.getPrice(), 0);
    }

    @Test
    public void dayRental() throws Exception {
        IRental dayRental = validBikeRentalFactory.createDayBikeRental();
        assertEquals("Rental length in hours for Day rentals should be 24.", 24, dayRental.getHours());
        assertEquals("Rental price for Day rentals should be 20.", 20, dayRental.getPrice(), 0);
    }

    @Test
    public void weekRental() throws Exception {
        IRental weekRental = validBikeRentalFactory.createWeekBikeRental();
        assertEquals("Rental length in hours for Day rentals should be 168.", 168, weekRental.getHours());
        assertEquals("Rental price for Day rentals should be 60.", 60, weekRental.getPrice(), 0);
    }

    @Test
    public void familyRentalByHourForThreeMembers() throws Exception {
        IRental familyRentalByHourForThreeMembers = validBikeRentalFactory.createFamilyRentalByHourForThreeMembers();
        assertEquals("Rental length in hours for Hour rentals for Three should be 1.", 1, familyRentalByHourForThreeMembers.getHours());
        assertEquals("Rental price for Hour rentals for Three should be 10,5.", 10.5, familyRentalByHourForThreeMembers.getPrice(), 0);
    }

    @Test
    public void familyRentalByHourForFourMembers() throws Exception {
        IRental familyRentalByHourForFourMembers = validBikeRentalFactory.createFamilyRentalByHourForFourMembers();
        assertEquals("Rental length in hours for Hour rentals for Four should be 1.", 1, familyRentalByHourForFourMembers.getHours());
        assertEquals("Rental price for Hour rentals for Four should be 14.", 14, familyRentalByHourForFourMembers.getPrice(), 0);
    }

    @Test
    public void familyRentalByHourForFiveMembers() throws Exception {
        IRental familyRentalByHourForFiveMembers = validBikeRentalFactory.createFamilyRentalByHourForFiveMembers();
        assertEquals("Rental length in hours for Hour rentals for Five should be 1.", 1, familyRentalByHourForFiveMembers.getHours());
        assertEquals("Rental price for Hour rentals for Five should be 17,5.", 17.5, familyRentalByHourForFiveMembers.getPrice(), 0);
    }

    @Test
    public void familyRentalByDayForThreeMembers() throws Exception {
        IRental familyRentalByHourForFiveMembers = validBikeRentalFactory.createFamilyRentalByDayForThreeMembers();
        assertEquals("Rental length in hours for Hour rentals for Three should be 24.", 24, familyRentalByHourForFiveMembers.getHours());
        assertEquals("Rental price for Day rentals for Three should be 42.", 42, familyRentalByHourForFiveMembers.getPrice(), 0);
    }

    @Test
    public void familyRentalByDayForFourMembers() throws Exception {
        IRental familyRentalByHourForFiveMembers = validBikeRentalFactory.createFamilyRentalByDayForFourMembers();
        assertEquals("Rental length in hours for Day rentals for Four should be 24.", 24, familyRentalByHourForFiveMembers.getHours());
        assertEquals("Rental price for Hour rentals for Four should be 56.", 56, familyRentalByHourForFiveMembers.getPrice(), 0);
    }

    @Test
    public void familyRentalByDayForFiveMembers() throws Exception {
        IRental familyRentalByHourForFiveMembers = validBikeRentalFactory.createFamilyRentalByDayForFiveMembers();
        assertEquals("Rental length in hours for Hour rentals for Five should be 24.", 24, familyRentalByHourForFiveMembers.getHours());
        assertEquals("Rental price for Hour rentals for Five should be 70.", 70, familyRentalByHourForFiveMembers.getPrice(), 0);
    }

    @Test
    public void familyRentalByWeekForThreeMembers() throws Exception {
        IRental familyRentalByWeekForThreeMembers = validBikeRentalFactory.createFamilyRentalByWeekForThreeMembers();
        assertEquals("Rental length in hours for Week rentals for Three should be 168.", 168, familyRentalByWeekForThreeMembers.getHours());
        assertEquals("Rental price for Week rentals for Three should be 126.", 126, familyRentalByWeekForThreeMembers.getPrice(), 0.000000001);
    }

    @Test
    public void familyRentalByWeekForFourMembers() throws Exception {
        IRental familyRentalByWeekForFourMembers = validBikeRentalFactory.createFamilyRentalByWeekForFourMembers();
        assertEquals("Rental length in hours for Week rentals for Four should be 168.", 168, familyRentalByWeekForFourMembers.getHours());
        assertEquals("Rental price for Week rentals for Four should be 168.", 168, familyRentalByWeekForFourMembers.getPrice(), 0);
    }

    @Test
    public void familyRentalByWeekForFiveMembers() throws Exception {
        IRental familyRentalByWeekForFiveMembers = validBikeRentalFactory.createFamilyRentalByWeekForFiveMembers();
        assertEquals("Rental length in hours for Week rentals for Five should be 168.", 168, familyRentalByWeekForFiveMembers.getHours());
        assertEquals("Rental price for Week rentals for Five should be 210.", 210, familyRentalByWeekForFiveMembers.getPrice(), 0);
    }

    @Test
    public void halfDayRental() {
        IRental halfDayRental = null;
        String message = null;
        try {
            halfDayRental = validBikeRentalFactory.createHalfDayRental();
        }
        catch(Exception ex) {
            message = ex.getMessage();
        }
        assertNull("HALF_DAY rental should be disabled.", halfDayRental);
        assertNotNull("Exception message should have been set when catching exception.", message);
        assertEquals("Exception message should indicate HALF_DAY rental is disabled.", "HALF_DAY rental is disabled.", message);
    }

}