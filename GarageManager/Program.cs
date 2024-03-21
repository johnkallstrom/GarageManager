// Could use DI instead
IGarage<IVehicle> garage = new Garage<IVehicle>(capacity: 20);
IHandler handler = new GarageHandler(garage);
IUserInterface consoleUI = new ConsoleUI();

var app = new Application(consoleUI, handler);
app.Run();

//try
//{
//	garage.Park(new Car("ABC123", "Green", 4));
//	garage.Park(new Car("FHS312", "Purple", 4));
//	garage.Park(new Car("SPE461", "Silver", 4));
//}
//catch (Exception ex)
//{
//	Console.WriteLine(ex.Message);
//}

//var dict = garage.GetAmountOfVehiclesByType();

//foreach (var v in garage)
//{
//	Console.WriteLine(v.ToString());
//}