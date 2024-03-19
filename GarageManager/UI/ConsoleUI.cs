namespace GarageManager
{
	internal class ConsoleUI : IUserInterface
	{
		public void Clear() => Console.Clear();

		public void Print(string message) => Console.WriteLine(message);

		public void PrintMenu(string title, string[] options)
		{
			Console.Clear();
            Console.WriteLine(title);

			foreach (var option in options)
			{
                Console.WriteLine(option);
            }
        }

		public int ReadInt(string prompt)
		{
			while (true)
			{
				Console.Write(prompt);
				if (int.TryParse(Console.ReadLine(), out int result))
				{
					return result;
				}
			}
		}

		public int ReadInt(string prompt, int min, int max)
		{
			while (true)
			{
				Console.Write(prompt);
				if (int.TryParse(Console.ReadLine(), out int result))
				{
					if (result >= min && result <= max)
					{
						return result;
					}
				}
			}
		}

		public string ReadString(string prompt)
		{
			while (true)
			{
				Console.Write(prompt);
				string? str = Console.ReadLine();

				if (!string.IsNullOrWhiteSpace(str))
				{
					return str;
				}
			}
		}
	}
}