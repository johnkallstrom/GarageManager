namespace GarageManager.UI
{
	internal static class InputReader
	{
		public static (bool IsValid, string Value) GetString(string prompt)
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

		public static (bool IsValid, int Value) GetInt(string prompt, int min, int max)
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
	}
}
