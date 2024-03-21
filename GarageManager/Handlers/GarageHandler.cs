
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

		public IEnumerable<IVehicle> GetAllParked() => _garage.ParkedVehicles;

		public void Remove(IVehicle vehicle) => _garage.Remove(vehicle);

		public string GetInformation() => _garage.Information();
	}
}
