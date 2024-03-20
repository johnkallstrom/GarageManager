// Could use DI instead
IGarage<IVehicle> garage = new Garage<IVehicle>(capacity: 10);
IHandler handler = new GarageHandler(garage);
IUserInterface consoleUI = new ConsoleUI();

//var app = new Application(consoleUI, handler);
//app.Run();

int spots = garage.AvailableSpots;

handler.Park(new Car("ABC123", "Green", 4));
handler.Park(new Car("ABC123", "Green", 4));
handler.Park(new Car("ABC123", "Green", 4));

spots = garage.AvailableSpots;

var collection = handler.GetAllParked();

foreach (var v in collection)
{
    Console.WriteLine(v.ToString());
}