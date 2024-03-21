namespace GarageManager.Handlers
{
	internal interface IHandler
	{
		void Populate(List<IVehicle> vehicles);
		void Remove(IVehicle vehicle);
		void Park(IVehicle vehicle);
		IEnumerable<IVehicle> GetAll();
		string GetInformation();
	}
}
