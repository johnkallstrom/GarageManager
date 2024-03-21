namespace GarageManager
{
	internal class ConsoleUI : IUserInterface
	{
        public void Space() => Console.WriteLine();
		public void Clear() => Console.Clear();

		public void Dots()
		{
			for (int i = 1; i <= 3; i++)
			{
				Console.Write(".");
				Thread.Sleep(500);
			}
		}

		public void Dots(int milliseconds)
		{
			for (int i = 1; i <= 3; i++)
			{
				Console.Write(".");
				Thread.Sleep(milliseconds);
			}
		}

		public void Print(string? message) => Console.WriteLine(message);

		public void Print(string? message, bool newLine)
		{
			if (!newLine) Console.Write(message);
			else Console.WriteLine(message);
		}

		public void DisplayMenu(string[] options)
		{
            foreach (var option in options)
			{
				Console.WriteLine(option);
			}

			Console.WriteLine();
		}

		public void DisplayMenu(string[] options, string title)
		{
            if (!string.IsNullOrWhiteSpace(title))
			{
                Console.WriteLine(title);
                Console.WriteLine();
            }

            foreach (var option in options)
			{
                Console.WriteLine(option);
            }

            Console.WriteLine();
        }

		public string? ReadString(string prompt)
		{
			Console.Write(prompt);
			string? input = Console.ReadLine();

			return input;
		}
	}
}