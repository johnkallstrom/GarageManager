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
				_ui.PrintMenu("Garage Manager", ["0. Exit"]);
				_isRunning = false;
			}
        }
	}
}
