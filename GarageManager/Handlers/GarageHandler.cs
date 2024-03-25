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

		public void Initialize(int numberOfVehicles)
		{
			var cars = new List<IVehicle>();

			for (int i = 0; i < numberOfVehicles; i++)
			{
				cars.Add(new Car($"ABC{new Random().Next(minValue: 100, maxValue: 999)}", "Green", 4));
			}

			_garage.Initialize(cars);
		}

		public Dictionary<string, int> GetNumberOfVehicles()
		{
			var result = _garage.GetNumberOfVehicles();
			return result;
		}

		public IEnumerable<IVehicle> Search(string searchTerm, SearchCategory category) => _garage.Search(searchTerm, category);

		public IVehicle GetByRegNumber(string registrationNumber) => _garage.GetByRegNumber(registrationNumber);
	}
}
