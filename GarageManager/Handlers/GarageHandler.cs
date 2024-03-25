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

		public IEnumerable<IVehicle> GetAllVehicles() => _garage.GetAllVehicles();

		public void Remove(IVehicle vehicle) => _garage.Remove(vehicle);

		public string Information() => _garage.Information();

		public void PopulateGarage(int amount)
		{
			var vehicles = new List<IVehicle>();
			for (int i = 0; i < amount; i++)
			{
				vehicles.Add(new Car($"ABC{new Random().Next(minValue: 100, maxValue: 999)}", "Green", 4));
			}

			_garage.Initialize(vehicles);
		}

		public Dictionary<string, int> GetNumberOfVehicles()
		{
			var result = _garage.GetNumberOfVehicles();
			return result;
		}

		public IEnumerable<IVehicle> Search(string searchTerm) => _garage.Search(searchTerm);

		public IVehicle GetByRegNumber(string registrationNumber) => _garage.GetByRegNumber(registrationNumber);
	}
}
