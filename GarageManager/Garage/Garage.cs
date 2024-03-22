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

		public void Initialize(List<T> vehicles)
		{
			foreach (var v in vehicles)
			{
				Park(v);
			}
		}

		public IEnumerable<T> GetAllVehicles() => _vehicles.Where(v => v is not null);

		public void Park(T vehicle)
		{
			if (vehicle is null) throw new ArgumentNullException(nameof(vehicle));
			if (IsFull) throw new Exception($"The garage is full");

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
			return $"Capacity: {TotalSpots}\nAvailable: {AvailableSpots}\nParked vehicles: {GetAllVehicles().Count()}";
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

			int amountOfCars = _vehicles.Where(v => v is Car).Count();
			int amountOfMotorcycles = _vehicles.Where(v => v is Motorcycle).Count();

			dictionary.Add(nameof(Car), amountOfCars);
			dictionary.Add(nameof(Motorcycle), amountOfMotorcycles);

			return dictionary;
		}
	}
}
