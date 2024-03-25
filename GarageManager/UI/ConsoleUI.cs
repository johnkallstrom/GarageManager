namespace GarageManager
{
	internal class ConsoleUI : IUserInterface
	{
		private List<Option> _menuOptions;

        public ConsoleUI(List<Option> menuOptions)
        {
			_menuOptions = menuOptions;
        }

		public void ShowMainMenu()
		{
			foreach (var option in _menuOptions)
			{
                Console.WriteLine($"{option.Key}. {option.Label}");
            }
		}

		public void Space() => Console.WriteLine();

		public void Clear() => Console.Clear();

		public void PrintMessage(string? message) => Console.WriteLine(message);

		public void PrintSubMenu(string[] options)
		{
            foreach (var option in options)
			{
				Console.WriteLine(option);
			}
		}

		public (bool IsValid, string Value) ReadString(string prompt)
		{
			bool valid = false;
			string str = string.Empty;

			Console.Write(prompt);
			str = Console.ReadLine()!;

			if (!string.IsNullOrWhiteSpace(str))
			{
				valid = true;
			}

			return (valid, str);
		}

		public void PrintMessageWithDots(string? message)
		{
			Console.Write(message);
			for (int i = 1; i <= 3; i++)
			{
				Console.Write(".");
				Thread.Sleep(1000);
			}
		}

		public (bool IsValid, int Value) ReadInt(string prompt)
		{
			bool valid = false;
			int num = 0;

			Console.Write(prompt);
			string? input = Console.ReadLine();
			if (int.TryParse(input, out int result))
			{
				valid = true;
				num = result;
			}

			return (valid, num);
		}

		public (bool IsValid, int Value) ReadInt(string prompt, int min, int max)
		{
			bool valid = false;
			int num = 0;

			Console.Write(prompt);
			string? input = Console.ReadLine();
			if (int.TryParse(input, out int result))
			{
				if (result >= min && result <= max)
				{
					valid = true;
					num = result;
				}
			}

			return (valid, num);
		}

		public (bool IsValid, IVehicle Vehicle) ReadVehicleData(VehicleType type)
		{
			bool valid = false;
			IVehicle vehicle = default!;

			var regNumber = ReadString("Registration number: ");
			var color = ReadString("Color: ");

			if (regNumber.IsValid && color.IsValid)
			{
				switch (type)
				{
					case VehicleType.Airplane:
						vehicle = new Airplane(regNumber.Value, color.Value, numberOfWheels: 0);
						valid = true;
						break;
					case VehicleType.Boat:
						vehicle = new Boat(regNumber.Value, color.Value, numberOfWheels: 0);
						valid = true;
						break;
					case VehicleType.Bus:
						vehicle = new Bus(regNumber.Value, color.Value, numberOfWheels: 4);
						valid = true;
						break;
					case VehicleType.Car:
						vehicle = new Car(regNumber.Value, color.Value, numberOfWheels: 4);
						valid = true;
						break;
					case VehicleType.Motorcycle:
						vehicle = new Motorcycle(regNumber.Value, color.Value, numberOfWheels: 2);
						valid = true;
						break;
					case VehicleType.Spaceship:
						vehicle = new Spaceship(regNumber.Value, color.Value,numberOfWheels: 0);
						valid = true;
						break;
				}
			}

			return (valid, vehicle);
		}
	}
}