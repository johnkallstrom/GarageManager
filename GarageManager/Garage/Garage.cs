[assembly: InternalsVisibleTo("GarageManager.Tests")]
namespace GarageManager.Garage
{
	internal class Garage<T> : IGarage<T> where T : IVehicle
	{
        private readonly T[] _spots;
		private int _capacity;

        public Garage(int capacity)
        {
            _capacity = capacity;
            _spots = new T[_capacity];
        }

		public int TotalSpots => _capacity;
        public int AvailableSpots => _spots.Where(x => x is null).Count();
		public bool IsFull => TotalSpots.Equals(Vehicles.Length);
		public T[] Vehicles => _spots.Where(x => x is not null).ToArray();

		public void Initialize(List<T> vehiclesToPark)
		{
			foreach (var v in vehiclesToPark)
			{
				Park(v);
			}
		}

		public void Park(T vehicle)
		{
			if (vehicle is null) throw new ArgumentNullException(nameof(vehicle));
			if (IsFull) throw new GarageIsFullException();

			for (int i = 0; i < _capacity; i++)
			{
				IVehicle current = _spots[i];
				if (current is null)
				{
					if (!RegNumberExists(vehicle.RegistrationNumber))
					{
						_spots[i] = vehicle;
						break;
					}
					else
					{
						throw new Exception($"The registration number '{vehicle.RegistrationNumber}' already exists");
					}
				}
			}
		}

		public void Remove(T vehicle)
		{
			if (vehicle is null) throw new ArgumentNullException(nameof(vehicle));

			for (int i = 0; i < _capacity; i++)
			{
				IVehicle current = _spots[i];
				if (current is not null && current.Equals(vehicle))
				{
					_spots[i] = default!;
					break;
				}
			}
		}

		public string Information()
		{
			return $"Total capacity: {TotalSpots}\nFree parking spots: {AvailableSpots}\nNumber of parked vehicles: {Vehicles.Length}";
		}

		public Dictionary<string, int> GetNumberOfVehicles()
		{
			var dictionary = new Dictionary<string, int>();

			int numberOfAirplanes = Vehicles.Where(v => v is Airplane).Count();
			int numberOfCars = Vehicles.Where(v => v is Car).Count();
			int numberOfMotorcycles = Vehicles.Where(v => v is Motorcycle).Count();
			int numberOfSpaceships = Vehicles.Where(v => v is Spaceship).Count();
			int numberOfBoats = Vehicles.Where(v => v is Boat).Count();
			int numberOfBuses = Vehicles.Where(v => v is Bus).Count();

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
			var query = Vehicles.AsQueryable();

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

			return query.ToList();
		}

		public T GetByRegNumber(string registrationNumber)
		{
			var vehicle = Vehicles.FirstOrDefault(v => v.RegistrationNumber.Equals(registrationNumber, StringComparison.OrdinalIgnoreCase));

			if (vehicle is null)
			{
				throw new Exception($"Could not find vehicle with registration number {registrationNumber}");
			}

			return vehicle;
		}

		private bool RegNumberExists(string registrationNumber)
		{
			return Vehicles.Any(v => registrationNumber.Equals(v.RegistrationNumber, StringComparison.OrdinalIgnoreCase));
		}

		public IEnumerator<T> GetEnumerator()
		{
			foreach (var vehicle in _spots)
			{
				yield return vehicle;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			foreach (var vehicle in _spots)
			{
				yield return vehicle;
			}
		}
	}
}
