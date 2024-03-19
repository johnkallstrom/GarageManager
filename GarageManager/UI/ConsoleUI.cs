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