namespace GarageManager.Handlers
{
	internal interface IGarageHandler
	{
		void RemoveVehicle(IVehicle vehicle);
		void ParkVehicle(IVehicle vehicle);
		IVehicle[] GetAll();
	}
}
