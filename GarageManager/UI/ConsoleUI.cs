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
                Console.WriteLine($"{option.Key} {option.Label}");
            }
		}

		public void Space() => Console.WriteLine();
		public void Clear() => Console.Clear();

		public void Print(string? message) => Console.WriteLine(message);

		public void DisplayMenu(string[] options)
		{
            foreach (var option in options)
			{
				Console.WriteLine(option);
			}
		}

		public string? ReadString(string prompt)
		{
			Console.Write(prompt);
			string? input = Console.ReadLine();

			return input;
		}

		public void Error(ErrorType errorType)
		{
			switch (errorType)
			{
				case ErrorType.InvalidInput:
                    Console.Write("Invalid input");
                    for (int i = 1; i <= 3; i++)
					{
						Console.Write(".");
						Thread.Sleep(500);
					}
					break;
			}
		}

		public void PrintWithDots(string? message)
		{
			Console.Write(message);
			for (int i = 1; i <= 3; i++)
			{
				Console.Write(".");
				Thread.Sleep(500);
			}
		}
	}
}