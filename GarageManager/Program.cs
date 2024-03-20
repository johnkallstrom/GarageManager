var app = new Application(new ConsoleUI());
app.Run();

//var garage = new Garage<IVehicle>(10);
//var handler = new GarageHandler(garage);

//handler.ParkVehicle(new Car("ABC123", "Red", 4));
//handler.ParkVehicle(new Car("ABC456", "Yellow", 4));
//handler.ParkVehicle(new Car("ABC789", "Purple", 4));
//handler.ParkVehicle(new Car("ABC412", "Blue", 4));
//handler.ParkVehicle(new Car("ABC435", "Green", 4));

//var vehicles = handler.GetAll();

//foreach (var vehicle in vehicles)
//{
//	if (vehicle is not null)
//	{
//		Console.WriteLine(vehicle.ToString());
//		Console.WriteLine();
//	}
//}