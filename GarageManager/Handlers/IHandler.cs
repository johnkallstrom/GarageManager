namespace GarageManager.Handlers
{
	internal interface IHandler
	{
		void PopulateGarage(int amount);
		void Remove(IVehicle vehicle);
		void Park(IVehicle vehicle);
		IEnumerable<IVehicle> GetAllVehicles();
		string Information();
		Dictionary<string, int> GetNumberOfVehicles();
	}
}
