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
				string information = _handler.Information();
				_ui.PrintMessage(information);
				_ui.Space();
				_ui.ShowMainMenu();

				var input = _ui.ReadString("Enter: ");
				switch (input.Value)
				{
					case "0":
						Exit();
						break;
					case "1":
						PopulateGarage();
						break;
					case "2":
						ListAllVehicles();
						break;
					case "3":
						ListNumberOfVehicles();
						break;
					case "4":
						SearchVehicles();
						break;
					case "5":
						ParkVehicle();
						break;
					case "6":
						RemoveVehicle();
						break;
					default:
						_ui.PrintMessageWithDots(ErrorMessage.InvalidInput);
						break;
				}
			}
		}

		private void PopulateGarage()
		{
			while (true)
			{
				_ui.Clear();
				_ui.PrintSubMenu(["0. Return"]);

				var number = _ui.ReadInt("Number: ");
				if (number.IsValid)
				{
					if (number.Value is 0) break;

					try
					{
						_handler.PopulateGarage(number.Value);
						_ui.PrintMessageWithDots($"{number.Value} vehicles added to garage");
					}
					catch (Exception ex)
					{
						_ui.PrintMessageWithDots(ex.Message);
					}
				}
				else
				{
					_ui.PrintMessageWithDots(ErrorMessage.InvalidInput);
				}
			}
		}

		private void ListAllVehicles()
		{
			while (true)
			{
				_ui.Clear();

				var vehicles = _handler.GetAllVehicles();

				if (vehicles.Count() > 0)
				{
					foreach (var v in vehicles)
					{
						_ui.PrintMessage(v.ToString());
						_ui.Space();
					}
				}
				else
				{
					_ui.PrintMessage("Garage is empty.");
				}

				_ui.PrintSubMenu(["0. Return"]);
				var input = _ui.ReadString("Enter: ");

				if (input.IsValid && input.Value.Equals("0")) break;
				else _ui.PrintMessageWithDots(ErrorMessage.InvalidInput);
			}
		}

		private void ListNumberOfVehicles()
		{
			while (true)
			{
				_ui.Clear();

				var data = _handler.GetNumberOfVehicles();
				foreach (var item in data)
				{
					string vehicle = item.Key;
					int number = item.Value;

					_ui.PrintMessage($"{vehicle}: {number}");
				}

				_ui.PrintSubMenu(["0. Return"]);
				var input = _ui.ReadString("Enter: ");

				if (input.IsValid && input.Value.Equals("0")) break;
				else _ui.PrintMessageWithDots(ErrorMessage.InvalidInput);
			}
		}

		private void SearchVehicles()
		{
			while (true)
			{
				_ui.Clear();

				var searchTerm = _ui.ReadString("Enter: ");
				if (searchTerm.IsValid)
				{
					var vehicles = _handler.Search(searchTerm.Value);
					if (vehicles.Count() > 0)
					{
						foreach (var v in vehicles)
						{
							_ui.PrintMessage(v.ToString());
						}
					}
					else
					{
						_ui.PrintMessage("Nothing found");
					}
				}

				_ui.PrintSubMenu(["1. Try again", "0. Return"]);
				var input = _ui.ReadInt("Enter: ", min: 0, max: 1);
				if (input.IsValid)
				{
					if (input.Value.Equals(0)) break;
					if (input.Value.Equals(1)) continue;
					else _ui.PrintMessageWithDots(ErrorMessage.InvalidInput);
				}
			}
		}

		private void ParkVehicle()
		{
			while (true)
			{
				_ui.Clear();
				_ui.PrintSubMenu(["1. Car", "2. Motorcycle", "0. Return"]);

				var input = _ui.ReadInt("Enter: ", min: 0, max: 2);
				if (input.IsValid)
				{
					if (input.Value is 0) break;

					var result = _ui.ReadVehicleData((VehicleType)input.Value);
					if (result.IsValid)
					{
						try
						{
							_handler.Park(result.Vehicle);
							_ui.PrintMessageWithDots($"{result.Vehicle.GetType().Name} parked in garage");
						}
						catch (Exception ex)
						{
							_ui.PrintMessageWithDots(ex.Message);
						}
					}
					else
					{
						_ui.PrintMessageWithDots(ErrorMessage.InvalidInput);
					}
				}
				else
				{
					_ui.PrintMessageWithDots(ErrorMessage.InvalidInput);
				}
			}
		}

		private void RemoveVehicle()
		{
			while (true)
			{
				_ui.Clear();
				_ui.PrintSubMenu(["0. Return"]);

				var input = _ui.ReadString("Registration number: ");
				if (input.IsValid)
				{
					if (input.Value.Equals("0")) break;

					try
					{
						IVehicle vehicle = _handler.GetByRegNumber(input.Value);
						_handler.Remove(vehicle);
						_ui.PrintMessageWithDots($"Completed. Vehicle with reg number {input.Value} removed");
					}
					catch (Exception ex)
					{
						_ui.PrintMessageWithDots(ex.Message);
					}
				}
				else
				{
					_ui.PrintMessageWithDots(ErrorMessage.InvalidInput);
				}
			}
		}

		private void Exit() => _isAppRunning = false;
	}
}
