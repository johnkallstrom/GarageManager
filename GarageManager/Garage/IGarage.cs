namespace GarageManager.Garage
{
	internal interface IGarage<T> : IEnumerable<T> where T : IVehicle
	{
		Dictionary<string, int> GetAmountOfVehiclesByType();
		bool RegistrationNumberExists(string registrationNumber);
		void Initialize(List<T> vehicles);
		int TotalSpots { get; }
		int AvailableSpots { get;  }
		IEnumerable<T> GetAllVehicles();
        void Park(T vehicle);
		void Remove(T vehicle);
		string Information();
	}
}
