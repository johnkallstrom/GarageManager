
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
				_ui.DisplayMenu(["1. List all parked vehicles", "2. Park vehicle", "3. Remove vehicle", "4. Information", "0. Return to main menu"]);

				string? input = _ui.ReadString("Enter: ");
				
				switch (input)
				{
					case GarageMenu.ListParkedVehicles:
						ListParkedVehicles();
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

		private void ListParkedVehicles()
		{
			while (true)
			{
				_ui.Clear();

				var vehicles = _handler.GetAllParked();

				if (vehicles.Count() > 0)
				{
					foreach (var v in vehicles)
					{
						_ui.Print(v.ToString());
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

		internal void Exit() => _isAppRunning = false;
	}
}
