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
				_ui.Clear();
				_ui.DisplayMenu(
					[
					"1. List all vehicles", 
					"2. List vehicles by type", 
					"3. Park vehicle", 
					"4. Remove vehicle", 
					"5. Information", 
					"6. Settings", 
					"0. Exit"
					]);

				string? input = _ui.ReadString("Enter: ");

				switch (input)
				{
					case MenuOption.ListAllVehicles:
						ListAllVehicles();
						break;
					case MenuOption.ListVehiclesByType:
						ListVehiclesByType();
						break;
					case MenuOption.ParkVehicle:
						ParkVehicle();
						break;
					case MenuOption.RemoveVehicle:
						RemoveVehicle();
						break;
					case MenuOption.Information:
						Information();
						break;
					case MenuOption.Settings:
						Settings();
						break;
					case MenuOption.Exit:
						Exit();
						break;
					default:
						_ui.Error(ErrorType.InvalidInput);
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
				}

				_ui.DisplayMenu(["0. Return"]);
				string? input = _ui.ReadString("Enter: ");

				if (!string.IsNullOrWhiteSpace(input) && input.Equals(MenuOption.Exit))
				{
					break;
				}
				else
				{
					_ui.Error(ErrorType.InvalidInput);
				}
			}
		}

		private void ListVehiclesByType()
		{
			while (true)
			{
				_ui.Clear();
				var data = _handler.GetAmountByType();

				foreach (var item in data)
				{
					_ui.Print($"{item.Key}: {item.Value}");
				}

				_ui.DisplayMenu(["0. Return"]);
				string? input = _ui.ReadString("Enter: ");

				if (!string.IsNullOrEmpty(input) && input.Equals(MenuOption.Exit)) break;
				else _ui.Error(ErrorType.InvalidInput);
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

				_ui.DisplayMenu(["0. Return"]);
				string? input = _ui.ReadString("Enter: ");

				if (!string.IsNullOrWhiteSpace(input) && input.Equals(MenuOption.Exit))
				{
					break;
				}
				else
				{
					_ui.Error(ErrorType.InvalidInput);
				}
			}
		}

		private void Settings()
		{
			bool running = true;
			while (running)
			{
				_ui.Clear();
				_ui.DisplayMenu(["1. Populate garage", "2. Set garage capacity", "0. Return"]);

				string? input = _ui.ReadString("Enter: ");
				switch (input)
				{
					case "1":
						try
						{
							// Todo: Read amount from user input
							int amount = 5;
							_handler.Populate(amount);
							_ui.PrintWithDots($"{amount} vehicles added to garage");
						}
						catch (Exception ex)
						{
							_ui.PrintWithDots(ex.Message);
						}
						break;
					case "2":
						// Todo: Read capacity from user input
						break;
					case "0":
						running = false;
						break;
					default:
						_ui.Error(ErrorType.InvalidInput);
						break;
				}
			}
		}

		private void Exit() => _isAppRunning = false;
	}
}
