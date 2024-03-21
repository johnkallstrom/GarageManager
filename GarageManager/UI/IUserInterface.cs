namespace GarageManager.UI
{
	public interface IUserInterface
    {
        void Print(string? message);
        void Print(string? message, bool newLine);
        void DisplayMenu(string[] options);
        void DisplayMenu(string[] options, string title);
        void Clear();
        string? ReadString(string prompt);
        void Dots();
        void Dots(int milliseconds);
        void Space();
    }
}
