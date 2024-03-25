namespace GarageManager.Garage
{
	internal class Garage<T> : IGarage<T> where T : IVehicle
	{
        private readonly T[] _vehicles;
		private int _capacity;

        public Garage(int capacity)
        {
            _capacity = capacity;
            _vehicles = new T[_capacity];
        }

		public int TotalSpots => _capacity;
        public int AvailableSpots => _vehicles.Where(v => v is null).Count();
		public bool IsFull => TotalSpots == GetAllVehicles().Count();

		public void Initialize(List<T> vehiclesToPark)
		{
			foreach (var v in vehiclesToPark)
			{
				Park(v);
			}
		}

		public IEnumerable<T> GetAllVehicles() => _vehicles.Where(v => v is not null);

		public void Park(T vehicle)
		{
			if (vehicle is null) throw new ArgumentNullException(nameof(vehicle));
			if (IsFull) throw new Exception("The garage is full");

			for (int i = 0; i < _capacity; i++)
			{
				IVehicle current = _vehicles[i];
				if (current is null)
				{
					if (!RegistrationNumberExists(vehicle.RegistrationNumber))
					{
						_vehicles[i] = vehicle;
						break;
					}
					else
					{
						throw new Exception($"The registration number '{vehicle.RegistrationNumber}' is not unique");
					}
				}
			}
		}

		public void Remove(T vehicle)
		{
			if (vehicle is null) throw new ArgumentNullException(nameof(vehicle));

			for (int i = 0; i < _capacity; i++)
			{
				IVehicle current = _vehicles[i];
				if (current is not null && current.Equals(vehicle))
				{
					_vehicles[i] = default!;
					break;
				}
			}
		}

		public string Information()
		{
			return $"Total capacity: {TotalSpots}\nFree parking spots: {AvailableSpots}\nNumber of parked vehicles: {GetAllVehicles().Count()}";
		}

		public IEnumerator<T> GetEnumerator()
		{
			foreach (var vehicle in _vehicles)
			{
				yield return vehicle;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			foreach (var vehicle in _vehicles)
			{
				yield return vehicle;
			}
		}

		public bool RegistrationNumberExists(string registrationNumber)
		{
			return _vehicles.Any(v => v is not null && registrationNumber.Equals(v.RegistrationNumber, StringComparison.OrdinalIgnoreCase));
		}

		public Dictionary<string, int> GetNumberOfVehicles()
		{
			var dictionary = new Dictionary<string, int>();

			int numberOfAirplanes = _vehicles.Where(v => v is Airplane).Count();
			int numberOfCars = _vehicles.Where(v => v is Car).Count();
			int numberOfMotorcycles = _vehicles.Where(v => v is Motorcycle).Count();
			int numberOfSpaceships = _vehicles.Where(v => v is Spaceship).Count();
			int numberOfBoats = _vehicles.Where(v => v is Boat).Count();
			int numberOfBuses = _vehicles.Where(v => v is Bus).Count();

			dictionary.Add(nameof(Airplane), numberOfAirplanes);
			dictionary.Add(nameof(Car), numberOfCars);
			dictionary.Add(nameof(Motorcycle), numberOfMotorcycles);
			dictionary.Add(nameof(Spaceship), numberOfSpaceships);
			dictionary.Add(nameof(Boat), numberOfBoats);
			dictionary.Add(nameof(Bus), numberOfBuses);

			return dictionary;
		}

		public IEnumerable<T> Search(string searchTerm, SearchCategory category)
		{
			var query = _vehicles.AsQueryable();

			query = query.Where(v => v != null);

			switch (category)
			{
				case SearchCategory.RegistrationNumber:
					query = query.Where(v => v.RegistrationNumber.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
					break;
				case SearchCategory.Color:
					query = query.Where(v => v.Color.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
					break;
				case SearchCategory.NumberOfWheels:
					query = query.Where(v => v.NumberOfWheels.Equals(int.Parse(searchTerm)));
					break;
			}

			var result = query.ToList();
			return result;
		}

		public T GetByRegNumber(string registrationNumber)
		{
			var vehicle = _vehicles.FirstOrDefault(v => v is not null && v.RegistrationNumber.Equals(registrationNumber, StringComparison.OrdinalIgnoreCase));

			if (vehicle is null)
			{
				throw new Exception($"Could not find vehicle with registration number {registrationNumber}");
			}

			return vehicle;
		}
	}
}
