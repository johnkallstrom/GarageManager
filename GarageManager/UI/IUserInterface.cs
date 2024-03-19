namespace GarageManager.UI
{
	public interface IUserInterface
    {
        void Print(string message);
        void PrintMenu(string title, string[] options);
        void Clear();
        string ReadString(string prompt);
    }
}
