namespace GarageManager.Handlers
{
	internal interface IHandler
	{
		void Remove(IVehicle vehicle);
		void Park(IVehicle vehicle);
		IEnumerable<IVehicle> GetAllParked();
		string GetInformation();
	}
}
