namespace GarageManager.Garage
{
	internal interface IGarage<T> : IEnumerable<T> where T : IVehicle
	{
		T GetByRegNumber(string registrationNumber);
		IEnumerable<T> Search(string searchTerm, SearchCategory category);
		Dictionary<string, int> GetNumberOfVehicles();
		void Initialize(List<T> vehicles);
		int TotalSpots { get; }
		int AvailableSpots { get;  }
		bool IsFull { get; }
		T[] Vehicles { get; }
        void Park(T vehicle);
		void Remove(T vehicle);
		string Information();
	}
}
