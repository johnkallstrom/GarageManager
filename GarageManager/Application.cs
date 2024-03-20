namespace GarageManager
{
	internal class Application
	{
		private bool _isAppRunning = true;
		private IUserInterface _ui;

		public Application(IUserInterface userInterface)
		{
			_ui = userInterface;
		}

		internal void Run()
		{
			while (_isAppRunning)
			{
				_ui.Clear();
				_ui.DisplayMenu(["1. Garage", "0. Exit"]);

				string? input = _ui.ReadString("Enter: ");
				switch (input)
				{
					case "1":
						Garage();
						break;
					case "0":
						Environment.Exit(0);
						break;
					default:
						_ui.Print("Incorrect input", newLine: false);
						_ui.Dots();
						break;
				}
			}
        }

		internal void Garage()
		{
			bool isRunning = true;

			while (isRunning)
			{
				_ui.Clear();
				_ui.DisplayMenu(["1. View all parked vehicles", "0. Return to main menu"]);

				string? input = _ui.ReadString("Enter: ");
				
				switch (input)
				{
					case "1":
						_ui.Print("Display list of vehicles...");
                        break;
					case "0":
						isRunning = false;
						break;
					default:
						_ui.Print("Incorrect input", newLine: false);
						_ui.Dots();
						break;
				}
			}
		}
	}
}
