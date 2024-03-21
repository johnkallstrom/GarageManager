
namespace GarageManager
{
	internal class Application
	{
		private IHandler _handler;
		private IUserInterface _ui;
		private bool _isAppRunning = true;

		public Application(IUserInterface userInterface, IHandler handler)
		{
			_ui = userInterface;
			_handler = handler;
		}

		internal void Run()
		{
			while (_isAppRunning)
			{
				// Todo: Replace magic strings
				_ui.Clear();
				_ui.DisplayMenu(["1. Garage", "0. Exit"]);

				string? input = _ui.ReadString("Enter: ");
				switch (input)
				{
					case AppMenu.Garage:
						Garage();
						break;
					case AppMenu.Exit:
						Exit();
						break;
					default:
						_ui.Print("Incorrect input", newLine: false);
						_ui.Dots();
						break;
				}
			}
        }

		private void Garage()
		{
			bool isRunning = true;

			while (isRunning)
			{
				// Todo: Replace magic strings
				_ui.Clear();
				_ui.DisplayMenu(["1. List all vehicles", "2. List vehicles by type", "3. Park vehicle", "4. Remove vehicle", "5. Information", "6. Populate garage", "0. Return to main menu"]);

				string? input = _ui.ReadString("Enter: ");
				
				switch (input)
				{
					case GarageMenu.ListAllVehicles:
						ListAllVehicles();
                        break;
					case GarageMenu.ListVehiclesByType:
						ListVehiclesByType();
						break;
					case GarageMenu.ParkVehicle:
						ParkVehicle();
						break;
					case GarageMenu.RemoveVehicle:
						RemoveVehicle();
						break;
					case GarageMenu.Information:
						Information();
						break;
					case GarageMenu.PopulateGarage:
						PopulateGarage();
						break;
					case GarageMenu.Return:
						isRunning = false;
						break;
					default:
						_ui.Print("Incorrect input", newLine: false);
						_ui.Dots();
						break;
				}
			}
		}

		private void ListAllVehicles()
		{
			while (true)
			{
				_ui.Clear();

				var vehicles = _handler.GetAll();

				if (vehicles.Count() > 0)
				{
					foreach (var v in vehicles)
					{
						_ui.Print(v.ToString());
						_ui.Space();
					}
				}
				else
				{
					_ui.Print("Garage is empty.");
					_ui.Space();
				}

				_ui.DisplayMenu(["0. Return"]);
				string? input = _ui.ReadString("Enter: ");

				if (!string.IsNullOrWhiteSpace(input) && input.Equals(GarageMenu.Return))
				{
					break;
				}
				else
				{
					_ui.Print("Incorret input", newLine: false);
					_ui.Dots();
				}
			}
		}

		private void ListVehiclesByType()
		{
			while (true)
			{
				_ui.Clear();
			}
		}

		private void ParkVehicle()
		{
		}

		private void RemoveVehicle()
		{
		}

		private void Information()
		{
			while (true)
			{
				_ui.Clear();

				string information = _handler.GetInformation();
				_ui.Print(information);
				_ui.Space();

				_ui.DisplayMenu(["0. Return"]);
				string? input = _ui.ReadString("Enter: ");

				if (!string.IsNullOrWhiteSpace(input) && input.Equals(GarageMenu.Return))
				{
					break;
				}
				else
				{
					_ui.Print("Incorret input", newLine: false);
					_ui.Dots();
				}
			}
		}

		private void PopulateGarage()
		{
			while (true)
			{
				_ui.Clear();
				_ui.DisplayMenu(["1. Add vehicles", "0. Return"]);
				string? input = _ui.ReadString("Enter: ");

				if (!string.IsNullOrWhiteSpace(input) && input.Equals("1"))
				{
					var vehicles = new List<IVehicle>
					{
						new Car("YTN103", "Green", 4),
						new Motorcycle("GHJ813", "Yellow", 2),
						new Car("XOL", "Blue", 4),
					};

					_handler.Populate(vehicles);

					_ui.Print($"{vehicles.Count()} vehicles added to garage.");
					_ui.Print("Returning", newLine: false);
					_ui.Dots(1000);

					break;
				}
				else if (!string.IsNullOrWhiteSpace(input) && input.Equals("0"))
				{
					break;
				}
				else
				{
					_ui.Print("Incorrect input", newLine: false);
					_ui.Dots();
				}
			}
		}

		internal void Exit() => _isAppRunning = false;
	}
}
