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

IGarage<IVehicle> garage = new Garage<IVehicle>(int.Parse(defaultCapacity!));
IHandler handler = new GarageHandler(garage);
IUserInterface consoleUI = new ConsoleUI(menuOptions);

var app = new Application(consoleUI, handler);
app.Run();