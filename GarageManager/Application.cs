namespace GarageManager
{
	internal class Application
	{
		private IHandler _handler;
		private IUserInterface _consoleUI;
		private bool _isAppRunning = true;

		public Application(IUserInterface userInterface, IHandler handler)
		{
			_consoleUI = userInterface;
			_handler = handler;
		}

		internal void Run()
		{
			while (_isAppRunning)
			{
				_consoleUI.Clear();
				string information = _handler.Information();
				_consoleUI.PrintMessage(information);
				_consoleUI.Space();
				_consoleUI.ShowMainMenu();

				var input = _consoleUI.ReadString("Enter: ");
				switch (input.Value)
				{
					case "0":
						Exit();
						break;
					case "1":
						ListAllVehicles();
						break;
					case "2":
						ListNumberOfVehicles();
						break;
					case "3":
						SearchVehicles();
						break;
					case "4":
						ParkVehicle();
						break;
					case "5":
						RemoveVehicle();
						break;
					default:
						_consoleUI.PrintMessageWithDots(ErrorMessage.InvalidInput);
						break;
				}
			}
		}

		private void ListAllVehicles()
		{
			while (true)
			{
				_consoleUI.Clear();

				var vehicles = _handler.GetAllVehicles();

				if (vehicles.Count() > 0)
				{
					foreach (var v in vehicles)
					{
						_consoleUI.PrintMessage(v.ToString());
						_consoleUI.Space();
					}
				}
				else
				{
					_consoleUI.PrintMessage("Garage is empty.");
				}

				_consoleUI.PrintSubMenu(["0. Return"]);
				var input = _consoleUI.ReadString("Enter: ");

				if (input.IsValid && input.Value.Equals("0")) break;
				else _consoleUI.PrintMessageWithDots(ErrorMessage.InvalidInput);
			}
		}

		private void ListNumberOfVehicles()
		{
			while (true)
			{
				_consoleUI.Clear();

				var data = _handler.GetNumberOfVehicles();
				foreach (var item in data)
				{
					string vehicle = item.Key;
					int number = item.Value;

					_consoleUI.PrintMessage($"{vehicle}: {number}");
				}

				_consoleUI.PrintSubMenu(["0. Return"]);
				var input = _consoleUI.ReadString("Enter: ");

				if (input.IsValid && input.Value.Equals("0")) break;
				else _consoleUI.PrintMessageWithDots(ErrorMessage.InvalidInput);
			}
		}

		private void SearchVehicles()
		{
			while (true)
			{
				_consoleUI.Clear();
				_consoleUI.PrintMessage("Choose search category");
				_consoleUI.PrintSubMenu(["1. Registration number", "2. Color", "3. Number of wheels", "0. Return"]);

				var input = _consoleUI.ReadInt("Enter: ", min: 0, max: 3);
				if (input.IsValid)
				{
					if (input.Value is 0) break;

					var searchTerm = _consoleUI.ReadString("Search: ");
					if (searchTerm.IsValid)
					{
						var vehicles = _handler.Search(searchTerm.Value, (SearchCategory)input.Value);
						if (vehicles.Count() > 0)
						{
							_consoleUI.Space();
							foreach (var v in vehicles)
							{
								_consoleUI.PrintMessage(v.ToString());
								_consoleUI.Space();
							}
						}
						else
						{
							_consoleUI.PrintMessageWithDots("No vehicles found");
							continue;
						}
					}
					else
					{
						_consoleUI.PrintMessageWithDots(ErrorMessage.InvalidInput);
						continue;
					}
				}
				else
				{
					_consoleUI.PrintMessageWithDots(ErrorMessage.InvalidInput);
					continue;
				}

				_consoleUI.PrintSubMenu(["1. Try again", "0. Return"]);
				input = _consoleUI.ReadInt("Enter: ", min: 0, max: 1);

				if (input.IsValid)
				{
					if (input.Value is 0) break;
					if (input.Value is 1) continue;
					else _consoleUI.PrintMessageWithDots(ErrorMessage.InvalidInput);
				}
			}
		}

		private void ParkVehicle()
		{
			while (true)
			{
				_consoleUI.Clear();
				_consoleUI.PrintSubMenu(["1. Airplane", "2. Boat", "3. Bus", "4. Car", "5. Motorcycle", "6. Spaceship", "0. Return"]);

				var input = _consoleUI.ReadInt("Enter: ", min: 0, max: 6);
				if (input.IsValid)
				{
					if (input.Value is 0) break;

					var result = _consoleUI.ReadVehicleData((VehicleType)input.Value);
					if (result.IsValid)
					{
						try
						{
							_handler.Park(result.Vehicle);
							_consoleUI.PrintMessageWithDots($"{result.Vehicle.GetType().Name} parked in garage");
						}
						catch (Exception ex)
						{
							_consoleUI.PrintMessageWithDots(ex.Message);
						}
					}
					else
					{
						_consoleUI.PrintMessageWithDots(ErrorMessage.InvalidInput);
					}
				}
				else
				{
					_consoleUI.PrintMessageWithDots(ErrorMessage.InvalidInput);
				}
			}
		}

		private void RemoveVehicle()
		{
			while (true)
			{
				_consoleUI.Clear();
				_consoleUI.PrintSubMenu(["0. Return"]);

				var input = _consoleUI.ReadString("Registration number: ");
				if (input.IsValid)
				{
					if (input.Value.Equals("0")) break;

					try
					{
						IVehicle vehicle = _handler.GetByRegNumber(input.Value);
						_handler.Remove(vehicle);
						_consoleUI.PrintMessageWithDots($"Completed. Vehicle with reg number {input.Value} removed");
					}
					catch (Exception ex)
					{
						_consoleUI.PrintMessageWithDots(ex.Message);
					}
				}
				else
				{
					_consoleUI.PrintMessageWithDots(ErrorMessage.InvalidInput);
				}
			}
		}

		private void Exit() => _isAppRunning = false;
	}
}
