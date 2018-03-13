using System.Collections.Generic;
using BikeRental.Contract;
using System.Xml.Linq;
using System.Linq;
using System;
using BikeRental.Model;
using System.Reflection;

namespace BikeRental.Service
{
    using BikeRental = BikeRental.Model.BikeRental;

    public class XmlBikeRentalTypesService : IBikeRentalTypesService
    {
        private XDocument xDocument;

        public XmlBikeRentalTypesService(XDocument xDocument)
        {
            this.xDocument = xDocument;
        }

        public IList<IBikeRental> GetBikeRentalTypes()
        {
            IList<IBikeRental> bikeRentalTypes = new List<IBikeRental>();
            var bikeRentalTypeElements = xDocument.Root.Descendants("bikeRentalType").ToList();
            foreach (var bikeRentalTypeElement in bikeRentalTypeElements)
            {
                try
                {
                    var bikeRentalType = this.CreateBikeRental(bikeRentalTypeElement);
                    bikeRentalTypes.Add(bikeRentalType);
                }
                catch (TargetInvocationException tiEx)
                {
                    Console.WriteLine(tiEx.InnerException.Message);
                }
            }            
            return bikeRentalTypes;
        }

        private IBikeRental CreateBikeRental(XElement x)
        {
            var name = x.Attribute("name").Value.ToString();
            int.TryParse(x.Attribute("lengthInHours").Value.ToString(), out int lengthInHours);
            int.TryParse(x.Attribute("unitPrice").Value.ToString(), out int unitPrice);
            var bikesAmountAttribute = x.Attribute("bikesAmount");
            var bikesAmount = 1;
            if (bikesAmountAttribute != null)
            {
                int.TryParse(bikesAmountAttribute.Value.ToString(), out bikesAmount);
            }

            IPriceStrategy thePriceStrategy = new DefaultPriceStrategy();
            var priceStrategies = x.Descendants("priceStrategy").ToList();
            if (priceStrategies.Any())
            {
                var priceStrategy = priceStrategies.First();
                var type = priceStrategy.Attribute("type").Value.ToString();

                var paramArrayList = new List<object>();
                var parameters = priceStrategy.Descendants("parameters").First();
                var parameterList = parameters.Descendants("parameter").ToList();
                foreach (XElement xElement in parameterList)
                {
                    int.TryParse(xElement.Attribute("value").Value.ToString(), out int value);
                    paramArrayList.Add(value);
                }
                var classType = Type.GetType(type);
                thePriceStrategy = (IPriceStrategy) Activator.CreateInstance(classType, paramArrayList.ToArray());
            }

            return new BikeRental(name, lengthInHours, unitPrice, bikesAmount, thePriceStrategy);
        }
    }
}
