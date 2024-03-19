namespace GarageManager
{
	internal class ConsoleUI : IUserInterface
	{
		public void Print(string message) => Console.WriteLine(message);
	}
}
