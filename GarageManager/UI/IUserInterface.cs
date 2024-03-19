namespace GarageManager.UI
{
	public interface IUserInterface
    {
        void Print(string message);
        void PrintMenu(string title, string[] options);
        void Clear();
        string ReadString(string prompt);
        int ReadInt(string prompt);
        int ReadInt(string prompt, int min, int max);
    }
}
