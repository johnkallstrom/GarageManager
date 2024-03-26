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

		public void PrintMessageWithDots(string? message)
		{
			Console.Write(message);
			for (int i = 1; i <= 3; i++)
			{
				Console.Write(".");
				Thread.Sleep(1000);
			}
		}
	}
}