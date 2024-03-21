// Could use DI instead
IGarage<IVehicle> garage = new Garage<IVehicle>(capacity: 20);
IHandler handler = new GarageHandler(garage);
IUserInterface consoleUI = new ConsoleUI();

var app = new Application(consoleUI, handler);
app.Run();