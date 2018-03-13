using BikeRental.Contract;
using System;
using System.Collections.Generic;

namespace BikeRental.Model
{
    public class BikeRentalFactory : IBikeRentalFactory
    {
        private IDictionary<string, IBikeRental> bikeRentalNameToInstanceMap;

        public BikeRentalFactory(IBikeRentalTypesService bikeRentalTypesService)
        {
            bikeRentalNameToInstanceMap = new Dictionary<string, IBikeRental>();
            IList<IBikeRental> bikeRentalTypes = bikeRentalTypesService.GetBikeRentalTypes();
            foreach (var bikeRental in bikeRentalTypes)
            {
                if (bikeRentalNameToInstanceMap.ContainsKey(bikeRental.Name))
                { 
                    Console.WriteLine(string.Format("{0} already exists in current Bike Rental Types. Duplicated Bike Rental Type will be ignored.", bikeRental.Name));
                    continue;
                }

                bikeRentalNameToInstanceMap.Add(bikeRental.Name, bikeRental);
            }            
        }

        public IBikeRental GetRentalByName(string rentalName)
        {
            if (!bikeRentalNameToInstanceMap.ContainsKey(rentalName))
                throw new KeyNotFoundException(string.Format("There is no rental configured with name {0}", rentalName));

            return bikeRentalNameToInstanceMap[rentalName];
        }

        public IBikeRental GetHourRental()
        {
            return GetRentalByName("Hour Rental");
        }

        public IBikeRental GetDayRental()
        {
            return GetRentalByName("Day Rental");
        }

        public IBikeRental GetWeekRental()
        {
            return GetRentalByName("Week Rental");
        }

        public IBikeRental GeFamilyHourRentalForThree()
        {
            return GetRentalByName("Family Hour Rental For Three");
        }

        public IBikeRental GeFamilyDayRentalForThree()
        {
            return GetRentalByName("Family Day Rental For Three");
        }

        public IBikeRental GeFamilyWeekRentalForThree()
        {
            return GetRentalByName("Family Week Rental For Three");
        }

        public IBikeRental GeFamilyWeekRentalForSix()
        {
            return GetRentalByName("Family Week Rental For Six");
        }

        public int GetBikeRentalsCount()
        {
            return bikeRentalNameToInstanceMap.Count;
        }
    }
}
