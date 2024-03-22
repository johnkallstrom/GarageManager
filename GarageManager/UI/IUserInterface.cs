namespace GarageManager.UI
{
    public interface IUserInterface
    {
        void ShowMainMenu();
        void Print(string? message);
        void PrintWithDots(string? message);
        void DisplayMenu(string[] options);
        void Clear();
        string? ReadString(string prompt);
        void Space();
        void Error(ErrorType errorType);
    }
}
