string dir = Directory.GetCurrentDirectory();
string dir1 = Environment.CurrentDirectory;

// Todo: Hämta sökvägen på ett bättre sätt
string path = @"C:\Git\GarageManager\GarageManager\";

IConfiguration configuration = new ConfigurationBuilder()
	.SetBasePath(path)
	.AddJsonFile("appsettings.json", false, reloadOnChange: true)
	.Build();

string? defaultCapacity = configuration.GetSection("Garage:DefaultCapacity").Value;
var menuOptions = configuration.GetSection("MenuOptions")
	.GetChildren()
	.Select(section => new Option(section.Key, section.Value!))
	.ToList();

// Todo: Använd DI istället
IUserInterface consoleUI = new ConsoleUI(menuOptions);

IGarage<IVehicle> garage = default!;
IHandler handler = default!;

while (true)
{
	consoleUI.Clear();

	var capacity = InputReader.GetInt("Garage capacity: ", min: 5, max: 100);
	if (capacity.IsValid)
	{
		garage = new Garage<IVehicle>(capacity.Value);
		handler = new GarageHandler(garage);

		var vehicleAmount = InputReader.GetInt("Number of vehicles: ", min: 1, max: capacity.Value);
		if (!vehicleAmount.IsValid)
		{
			consoleUI.PrintMessageWithDots(ErrorMessage.InvalidInput);
			continue;
		}

		handler.Initialize(vehicleAmount.Value);

		consoleUI.PrintMessageWithDots($"Garage capacity set to {capacity.Value} and {vehicleAmount.Value} vehicle(s) has been added");
		break;
	}

	consoleUI.PrintMessageWithDots(ErrorMessage.InvalidInput);
}

var app = new Application(consoleUI, handler);
app.Run();