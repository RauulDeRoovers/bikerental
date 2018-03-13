Notes
-----
- I'm assuming promotion rentals accept any kind of rental, between 3 and 5 "units", with the sole condition of each "unit" being the same kind.
- As a first step for improvement, we could add an XSD schema definition for the BikeRentalTypes in XML files. I didn't include it seems I believe it goes beyond the scope of the
	exercise. The drawbacks of not having the XSD schema definition are visible when reading attributes and values which are not forced by schema (name, lengthInHours, etc.).
- I've used Console as default log. We could improve it by injecting a logging component implementing a given interface.
- The GeFamilyWeekRentalForThreeTest test method presents a small difference compared with other test methods: it provides a delta value for the Total Price calculation to deal 
	with rounding.
- Another improvement step would be to add test methods for Family Day/Week Rentals for Three/Four/Five. I've not included these since they do not add to code coverage. Bike Rental
	Types, however, are included in the BikeRentalTypes.xml file.

Design
------
- The design considers three main projects: Contract, Model and Service.
	* Contract: holds the interfaces that define the interaction between the different components and provide a means to extend the model and still comply with basic requirements.
	* Model: holds all classes that represent our domain model.
	* Service: holds a sole class that implements a means to read all available Bike Rental Types using XML files. We could add further classes retrieving available Bike Rental
		Types from different sources.
- Contract 
	* IBikeRental: defines the base structure to be followed by our main domain model class, representing the Rental itself.
	* IBikeRentalFactory: defines the base calls to get most of our supported Rentals. We should add a few to fully support our model:
		+ IBikeRental GeFamilyHourRentalForFour();
        + IBikeRental GeFamilyDayRentalForFour();
        + IBikeRental GeFamilyWeekRentalForFour();
		+ IBikeRental GeFamilyHourRentalForFive();
        + IBikeRental GeFamilyDayRentalForFive();
        + IBikeRental GeFamilyWeekRentalForFive();
	* IBikeRentalTypesService: defines base format to follow when retrieving available Bike Rental Types.
	* IPriceStrategy: defines base format to follow to calculate total price for Rentals.
- Model
	* BikeRental: main model class. Supports different Bike Amounts, Length in hours, Unit Price and Total Price. Depends on IPriceStrategy to calculate Total Price.
	* BikeRentalFactory: provides a clear way for creating different Bike Rentals. Instead of forcing end "user" to know the specifics, it provides a more declarative interface.
	* DefaultPriceStrategy: implements the default price calculation strategy, by returning the Unit Price value.
	* DiscountPriceStrategy: implements a discount strategy using the recieved discount amount.
- Service
	* XmlBikeRentalTypesService: retrieves all available Bike Rental Types by using provided XML file.
	

Practices
---------
- I've used a factory to ease BikeRental creation. It's a declarative approach for the user not to be forced to know the specifics. This way we can hide implementation if we
	wanted to.
- Several interfaces: even if the size of the exercise is small, by using interfaces we can easily change implementations. Even further, using a dependency injection framework,
	we can provide different services and factories as long as they all implement the proper interface.
- Inheritance: I've not used inheritance since I focused in model flexibility. By having a unique BikeRental class with an open declaration that supports all required features
	(Bikes Amount, Length in hours, different Pricing strategies, etc.) we could easily add several Bike Rental Types by just providing them through an XML file (in the example
	provided). This way, we can add Bike Rental Types "on the fly" without having to re-deploy any component. Furthermore, if we needed other Pricing Strategies, we would only 
	have to add it to Model project and re-deploy the Model class library, the reference this new class in the "priceStrategy" element's "type" attribute. Since we are creating
	the Price Strategy using reflection, we can provide any amount of parameters. In the example, we privded just one, since it is all it takes to create an instance of the 
	DiscountPriceStrategy class.
- I've used AxoCover extension to check Code Coverage.


How to run tests
----------------
- Import solution into Visual Studio.
- Compile solution (Ctrl+Shift+B).
- Go to "Test" -> "Execute" -> "All tests" (Ctrl+R+,A).
