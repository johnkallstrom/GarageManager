namespace GarageManager.UI
{
	internal interface IUserInterface
    {
        void ShowMainMenu();
        void PrintMessage(string? message);
        void PrintMessageWithDots(string? message);
        void PrintSubMenu(string[] options);
        void Clear();
        void Space();
    }
}
