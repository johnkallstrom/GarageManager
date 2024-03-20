namespace GarageManager.Handlers
{
	internal class GarageHandler : IGarageHandler
	{
		private IGarage<IVehicle> _garage;

		public GarageHandler(IGarage<IVehicle> garage)
		{
			_garage = garage;
		}

		public IVehicle[] GetAll() => _garage.Vehicles;

		public void ParkVehicle(IVehicle vehicle) => _garage.Park(vehicle);

		public void RemoveVehicle(IVehicle vehicle) => _garage.Remove(vehicle);
	}
}
