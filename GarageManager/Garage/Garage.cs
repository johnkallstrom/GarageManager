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

		public void Initialize(List<T> vehicles)
		{
			foreach (var v in vehicles)
			{
				Park(v);
			}
		}

		public int TotalSpots => _capacity;
        public int AvailableSpots => _vehicles.Where(v => v is null).Count();

		public IEnumerable<T> GetAllVehicles()
		{
			return _vehicles.Where(v => v is not null);
		}

		// Todo: Check registration number before adding (must be unique)
		public void Park(T vehicle)
		{
			if (vehicle is null) throw new ArgumentNullException(nameof(vehicle));

			for (int i = 0; i < _capacity; i++)
			{
				IVehicle current = _vehicles[i];
				if (current is null)
				{
					_vehicles[i] = vehicle;
					break;
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
			return $"Total capacity: {TotalSpots}\nAvailable spots: {AvailableSpots}\nNumber of parked vehicles: {GetAllVehicles().Count()}";
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
	}
}
