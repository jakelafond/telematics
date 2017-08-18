This will include the defacto package for working with JSON Objects

## Assignment
Telematics data is the information about a vehicle that is sent on an interval (e.g. every x minutes or hours or miles) or when certain events happen (e.g. warning light).

Write a VehicleInfo class that has the following information:
* VIN (Vehicle Identification Number) - int
* odometer (miles traveled) - double
* consumption (gallons of gas consumed) - double
* odometer reading for last oil change - double
* engine size in liters (e.g. 2.0, 4.5) - double

The VehicleInfo class should be a POCO.

Write a TelematicsService class and implement the following method
`void Report(VehicleInfo vehicleInfo)`

In the `Main()` method of Main get the information for the VehicleInfo from the command line (i.e. Scanner). Do not write code for error handling the input, just the green path (i.e. type in the correct stuff).

Once all the info for a VehicleInfo has been entered and a VehicleInfo object has been created the `Report(vehicleInfo)` method in the TelematicsService should be called. This method should:
1. Write the VehicleInfo to a file as json using the VIN as the name of the file and a "json" extension (e.g. "234235435.json"). The file will overwrite any existing files for the same VIN.
2. Find all the files that end with ".json" and convert back to a VehicleInfo object.
3. Update a dashboard.html (only show 1 place after the decimal for values that are doubles). The dashboard.html should look something like this (with the '#' replaced with a number)
