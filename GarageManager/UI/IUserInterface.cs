namespace GarageManager.UI
{
	public interface IUserInterface
    {
        void Print(string? message);
        void Print(string? message, bool newLine);
        void DisplayMenu(string[] options);
        void Clear();
        string? ReadString(string prompt);
        void Dots();
        void Dots(int milliseconds);
        void Space();
        void Error(ErrorType errorType);
    }
}
