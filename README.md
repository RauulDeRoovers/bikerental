Notes
-----
- I'm assuming promotion rentals accept any kind of rental, between 3 and 5 "units", with the sole condition of each "unit" being the same kind.

Design
------
- We have a main class called "BikeRental" which holds the amount of hours for the given rental, along with the final price for the same.
- To instantiate "BikeRental" we use "BikeRentalType". This class is used to hold all current available rental types (plus one disabled rental type for testing purposes).
	The "BikeRentalType" can easily be replaced with similar classes if the domain is to be extended. The idea is to provide the "BikeRentalFactory" class with all available
	rental configurations. This could be done through a configuration file, database, etc. I've selected the enum way for simplicity. A good practice would be to use a dependency
	injection framework so we can provide a production configuration and use a test configuration separately, we could even change the implementation of the configuration provider
	by just updating the specific dependency.
- "BikeRentalType" supports individual or group rentals, with configuration for rental hour length and rental price, group size and and raw approximation to price calculation
	strategies. I've used a default strategy being the base rental price and I've assumed all group rentals will use the discount price strategy. It's not difficult to replace
	any of this strategies if we want them to be provided by a configuration object. The pricing strategy classes are "DefaultPriceStrategy" and "DiscountPriceStrategy". Both
	concrete classes inherit from a base class called "BasePriceStrategy" which implements the "IPriceStrategy". "BasePriceStrategy" holds a reference to the "BikeRentalType"
	each instance should use to calculate the final price. The "IPriceStrategy" simply indicates what each implementor should do, basically, calculate the final price - for
	a given rental, under current scope -.
- I've provided a "Half Day" rental as a demonstration of how the model could be leveraged by just adding configurations instead of new classes. At the same time, it's useful to
	evaluate different paths in the "BikeRentalFactory".
- "BikeRentalFactory" is the main point to interact with any UI. It provides methods to create each of the current required rentals plus a sample rental for testing purposes.
	The factory helps us canalize all rental creation calls and by switching provided configuration we could have different sources for our rentals.
- "IRental" interface is not 100% needed under this domain model, but it surely helps keeping things at a more abstract level if we wanted to add other rental types. As long as
	we follow the "hour & price" contract, we could leverage and/or extend our model with any kind of rental.

Practices
---------
- "BikeRentalFactory" is a common practice to ease access to resources by hiding specifics.
- "IPriceStrategy" and classes deriving from "BasePriceStrategy" follow the "Strategy" pattern. The idea here is to calculate the final rental price under different conditions
	or following different approaches. This might come in handy if different promotions were required.
- "BikeRentalFactory" also uses maps instead of other older/visually uglier structures such as infinite "if-else" methods or "swtich" statements.

How to run tests
----------------
- In AndroidStudio, import classes and interfaces.
- Right-click over "BikeRentalUnitTest" under "com.example.raderoovers.bikerental (test)".
- Click on "Run 'BikeRentalUnitTest'".