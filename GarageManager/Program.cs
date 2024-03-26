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

	int min = 1;
	int max = 500;

	var capacity = InputReader.GetInt("Garage capacity: ", min, max);
	if (!capacity.IsValid)
	{
		consoleUI.PrintMessageWithDots($"The capacity must be between {min} and {max}");
		continue;
	}

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

var app = new Application(consoleUI, handler);
app.Run();