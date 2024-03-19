namespace GarageManager
{
	internal class Application
	{
		private IUserInterface _ui;

		public Application(IUserInterface userInterface)
		{
			_ui = userInterface;
		}

		internal void Run()
		{
			_ui.Print("Garage Manager");
        }
	}
}
