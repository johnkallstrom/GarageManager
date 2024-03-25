﻿namespace GarageManager
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
						_ui.PrintMessageWithDots(ErrorMessage.InvalidInput);
						break;
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
				_ui.PrintMessage("Choose search category");
				_ui.PrintSubMenu(["1. Registration number", "2. Color", "3. Number of wheels", "0. Return"]);

				var input = _ui.ReadInt("Enter: ", min: 0, max: 3);
				if (input.IsValid)
				{
					if (input.Value is 0) break;

					var searchTerm = _ui.ReadString("Search: ");
					if (searchTerm.IsValid)
					{
						var vehicles = _handler.Search(searchTerm.Value, (SearchCategory)input.Value);
						if (vehicles.Count() > 0)
						{
							_ui.Space();
							foreach (var v in vehicles)
							{
								_ui.PrintMessage(v.ToString());
								_ui.Space();
							}
						}
						else
						{
							_ui.PrintMessageWithDots("No vehicles found");
							continue;
						}
					}
					else
					{
						_ui.PrintMessageWithDots(ErrorMessage.InvalidInput);
						continue;
					}
				}
				else
				{
					_ui.PrintMessageWithDots(ErrorMessage.InvalidInput);
					continue;
				}

				_ui.PrintSubMenu(["1. Try again", "0. Return"]);
				input = _ui.ReadInt("Enter: ", min: 0, max: 1);

				if (input.IsValid)
				{
					if (input.Value is 0) break;
					if (input.Value is 1) continue;
					else _ui.PrintMessageWithDots(ErrorMessage.InvalidInput);
				}
			}
		}

		private void ParkVehicle()
		{
			while (true)
			{
				_ui.Clear();
				_ui.PrintSubMenu(["1. Airplane", "2. Boat", "3. Bus", "4. Car", "5. Motorcycle", "6. Spaceship", "0. Return"]);

				var input = _ui.ReadInt("Enter: ", min: 0, max: 6);
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
