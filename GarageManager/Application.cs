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

				var input = InputReader.GetString("Enter: ");
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
				var input = InputReader.GetString("Enter: ");

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
				var input = InputReader.GetString("Enter: ");

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

				var input = InputReader.GetInt("Enter: ", min: 0, max: 3);
				if (input.IsValid)
				{
					if (input.Value is 0) break;

					var searchTerm = InputReader.GetString("Search: ");
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
				input = InputReader.GetInt("Enter: ", min: 0, max: 1);

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
				_consoleUI.PrintSubMenu(["1. Airplane", "2. Boat", "3. Bus", "4. Car", "5. Motorcycle", "6. Spacecraft", "0. Return"]);

				var input = InputReader.GetInt("Enter: ", min: 0, max: 6);
				if (!input.IsValid)
				{
					_consoleUI.Error();
					continue;
				}

				if (input.Value is 0) break;

				var vehicleType = (VehicleType)input.Value;
				switch (vehicleType)
				{
					case VehicleType.Airplane:
						ParkAirplane();
						break;
					case VehicleType.Boat:
						ParkBoat();
						break;
					case VehicleType.Bus:
						ParkBus();
						break;
					case VehicleType.Car:
						ParkCar();
						break;
					case VehicleType.Motorcycle:
						ParkMotorcycle();
						break;
					case VehicleType.Spacecraft:
						ParkSpacecraft();
						break;
				}
			}
		}

		private void ParkAirplane()
		{
			while (true)
			{
				_consoleUI.Clear();
				_consoleUI.PrintMessage("Enter airplane details");

				var regNumber = InputReader.GetString("Registration number: ");
				if (!regNumber.IsValid)
				{
					_consoleUI.Error();
					continue;
				}

				var color = InputReader.GetString("Color: ");
				if (!color.IsValid)
				{
					_consoleUI.Error();
					continue;
				}

				var model = InputReader.GetString("Model: ");
				if (!model.IsValid)
				{
					_consoleUI.Error();
					continue;
				}

				var numberOfEngines = InputReader.GetInt("Number of engines: ", min: 2, max: 4);
				if (!numberOfEngines.IsValid)
				{
					_consoleUI.Error();
					continue;
				}

				var airplane = new Airplane(regNumber.Value, color.Value, numberOfWheels: 0, model.Value, numberOfEngines.Value);
				_handler.Park(airplane);
				_consoleUI.PrintMessageWithDots($"{airplane.GetType().Name} parked in garage");
				break;
			}
		}

		private void ParkBoat()
		{
			while (true)
			{
				_consoleUI.Clear();
				_consoleUI.PrintMessage("Enter boat details");

				var regNumber = InputReader.GetString("Registration number: ");
				if (!regNumber.IsValid)
				{
					_consoleUI.Error();
					continue;
				}

				var color = InputReader.GetString("Color: ");
				if (!color.IsValid)
				{
					_consoleUI.Error();
					continue;
				}

				_consoleUI.PrintSubMenu(["1. Inboard motor", "2. Outboard motor", "3. Fan", "4. Wind"]);
				var propulsion = InputReader.GetInt("Enter: ", min: 1, max: 4);
				if (!propulsion.IsValid)
				{
					_consoleUI.Error();
					continue;
				}

				var boat = new Boat(regNumber.Value, color.Value, numberOfWheels: 0, (BoatPropulsion)propulsion.Value);
				_handler.Park(boat);
				_consoleUI.PrintMessageWithDots($"{boat.GetType().Name} parked in garage");
				break;
			}
		}

		private void ParkBus()
		{
			while (true)
			{
				_consoleUI.Clear();
				_consoleUI.PrintMessage("Enter bus details");

				var regNumber = InputReader.GetString("Registration number: ");
				if (!regNumber.IsValid)
				{
					_consoleUI.Error();
					continue;
				}

				var color = InputReader.GetString("Color: ");
				if (!color.IsValid)
				{
					_consoleUI.Error();
					continue;
				}

				var input = InputReader.GetString("Double decker (Y/N): ");
				if (!input.IsValid)
				{
					_consoleUI.Error();
					continue;
				}

				var bus = new Bus(regNumber.Value, color.Value, numberOfWheels: 4, input.Value == "Y" ? true : false);
				_handler.Park(bus);
				_consoleUI.PrintMessageWithDots($"{bus.GetType().Name} parked in garage");
				break;
			}
		}

		private void ParkCar()
		{
			while (true)
			{
				_consoleUI.Clear();
				_consoleUI.PrintMessage("Enter car details");

				var regNumber = InputReader.GetString("Registration number: ");
				if (!regNumber.IsValid)
				{
					_consoleUI.Error();
					continue;
				}

				var color = InputReader.GetString("Color: ");
				if (!color.IsValid)
				{
					_consoleUI.Error();
					continue;
				}

				var model = InputReader.GetString("Model: ");
				if (!model.IsValid)
				{
					_consoleUI.Error();
					continue;
				}

				var car = new Car(regNumber.Value, color.Value, numberOfWheels: 4, model.Value);
				_handler.Park(car);
				_consoleUI.PrintMessageWithDots($"{car.GetType().Name} parked in garage");
				break;
			}
		}

		private void ParkMotorcycle()
		{
			while (true)
			{
				_consoleUI.Clear();
				_consoleUI.PrintMessage("Enter motorcycle details");

				var regNumber = InputReader.GetString("Registration number: ");
				if (!regNumber.IsValid)
				{
					_consoleUI.Error();
					continue;
				}

				var color = InputReader.GetString("Color: ");
				if (!color.IsValid)
				{
					_consoleUI.Error();
					continue;
				}

				var model = InputReader.GetString("Model: ");
				if (!model.IsValid)
				{
					_consoleUI.Error();
					continue;
				}


				var topSpeed = InputReader.GetInt("Top speed: ", min: 5, max: 500);
				if (!topSpeed.IsValid)
				{
					_consoleUI.Error();
					continue;
				}

				var motorcycle = new Motorcycle(regNumber.Value, color.Value, numberOfWheels: 2, topSpeed.Value);
				_handler.Park(motorcycle);
				_consoleUI.PrintMessageWithDots($"{motorcycle.GetType().Name} parked in garage");
				break;
			}
		}

		private void ParkSpacecraft()
		{
			while (true)
			{
				_consoleUI.Clear();
				_consoleUI.PrintMessage("Enter spacecraft details");

				var regNumber = InputReader.GetString("Registration number: ");
				if (!regNumber.IsValid)
				{
					_consoleUI.Error();
					continue;
				}

				var color = InputReader.GetString("Color: ");
				if (!color.IsValid)
				{
					_consoleUI.Error();
					continue;
				}

				_consoleUI.PrintSubMenu(["1. Observation", "2. Exploration", "3. Transportation", "4. Communication"]);
				var purpose = InputReader.GetInt("Purpose of spaceflight: ", min: 1, max: 4);
				if (!purpose.IsValid)
				{
					_consoleUI.Error();
					continue;
				}

				var spacecraft = new Spacecraft(regNumber.Value, color.Value, numberOfWheels: 0, (SpaceflightPurpose)purpose.Value);
				_handler.Park(spacecraft);
				_consoleUI.PrintMessageWithDots($"{spacecraft.GetType().Name} parked in garage");
				break;
			}
		}

		private void RemoveVehicle()
		{
			while (true)
			{
				_consoleUI.Clear();
				_consoleUI.PrintSubMenu(["0. Return"]);

				var input = InputReader.GetString("Registration number: ");
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
