namespace GarageManager
{
	internal class Application
	{
		private IHandler _handler;
		private IUserInterface _ui;
		private bool _isAppRunning = true;

		public Application(IUserInterface userInterface, IHandler handler)
		{
			_ui = userInterface;
			_handler = handler;
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
					case AppMenu.Garage:
						Garage();
						break;
					case AppMenu.Exit:
						Exit();
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
					case GarageMenu.ViewAllVehicles:
						_ui.Clear();
                        break;
					case GarageMenu.Return:
						isRunning = false;
						break;
					default:
						_ui.Print("Incorrect input", newLine: false);
						_ui.Dots();
						break;
				}
			}
		}

		internal void Exit() => _isAppRunning = false;
	}
}
