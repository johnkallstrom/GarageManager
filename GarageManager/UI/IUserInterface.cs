namespace GarageManager.UI
{
	internal interface IUserInterface
    {
        void ShowMainMenu();
        void PrintMessage(string? message);
        void PrintMessageWithDots(string? message);
        void PrintSubMenu(string[] options);
        void Clear();
        (bool IsValid, IVehicle Vehicle) ReadVehicleData(VehicleType type);
        (bool IsValid, string Value) ReadString(string prompt);
        (bool IsValid, int Value) ReadInt(string prompt);
        (bool IsValid, int Value) ReadInt(string prompt, int min, int max);
        void Space();
    }
}
