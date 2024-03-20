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

		public T[] Vehicles => _vehicles;

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
