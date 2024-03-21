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

		public void Populate()
		{
			var vehicles = new List<IVehicle>
			{
				new Car("YTN103", "Green", 4),
				new Motorcycle("GHJ813", "Yellow", 2),
				new Car("PDN", "Blue", 4),
				new Motorcycle("GHJ813", "Red", 2),
				new Car("WCV", "Purple", 4),
			};

			_garage.Initialize(vehicles);
		}
	}
}
