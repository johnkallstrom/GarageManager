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

		public void Populate(int amount)
		{
			var vehicles = new List<IVehicle>();
			for (int i = 0; i < amount; i++)
			{
				vehicles.Add(new Car($"ABC{new Random().Next(minValue: 100, maxValue: 999)}", "Green", 4));
			}

			_garage.Initialize(vehicles);
		}

		public Dictionary<string, int> GetAmountByType()
		{
			var result = _garage.GetAmountOfVehiclesByType();
			return result;
		}
	}
}
