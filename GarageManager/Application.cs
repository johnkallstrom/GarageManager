namespace GarageManager
{
	internal class Application
	{
		private bool _isRunning = true;
		private IUserInterface _ui;

		public Application(IUserInterface userInterface)
		{
			_ui = userInterface;
		}

		internal void Run()
		{
			while (_isRunning)
			{
				_ui.PrintMenu("Garage Manager", ["1. Garage", "0. Exit"]);
				int selection = _ui.ReadInt("Enter: ", min: 0, max: 1);

				switch (selection)
				{
					case (int)Option.Garage:
						_ui.Clear();
						_ui.Print("View Garage");
						break;
					case (int)Option.Exit:
						Environment.Exit(0);
						break;
				}

				_isRunning = false;
			}
        }
	}
}
