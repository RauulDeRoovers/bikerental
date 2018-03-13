using System.Collections.Generic;

namespace BikeRental.Contract
{
    public interface IBikeRentalTypesService
    {
        IList<IBikeRental> GetBikeRentalTypes();
    }
}
