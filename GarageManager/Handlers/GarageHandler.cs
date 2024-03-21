namespace GarageManager.Handlers
{
	internal class GarageHandler : IHandler
	{
		private IGarage<IVehicle> _garage;

		public GarageHandler(IGarage<IVehicle> garage)
		{
			_garage = garage;
		}

		public void Park(IVehicle vehicle) => _garage.Park(vehicle);

		public IEnumerable<IVehicle> GetAll() => _garage.GetAllVehicles();

		public void Remove(IVehicle vehicle) => _garage.Remove(vehicle);

		public string GetInformation() => _garage.Information();

		public void Populate(List<IVehicle> vehicles) => _garage.Initialize(vehicles);
	}
}
