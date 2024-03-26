string GetProjectDirectoryPath()
{
	string workingDirectory = Environment.CurrentDirectory;
	string projectDirectory = Directory.GetParent(workingDirectory)!.Parent!.Parent!.FullName;

	return projectDirectory;
}

string path = GetProjectDirectoryPath();

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

		var vehicleAmount = InputReader.GetInt("Number of vehicles: ", min: 0, max: capacity.Value);
		if (!vehicleAmount.IsValid)
		{
			consoleUI.Error();
			continue;
		}

		if (vehicleAmount.Value > 0)
		{
			handler.Initialize(vehicleAmount.Value);
		}

		consoleUI.PrintMessageWithDots($"Initializing garage");
		break;
	}

	consoleUI.Error();
}

var app = new Application(consoleUI, handler);
app.Run();