namespace GarageManager.Garage
{
	internal interface IGarage<T> : IEnumerable<T> where T : IVehicle
	{
		int TotalSpots { get; }
		int AvailableSpots { get;  }
        IEnumerable<T> ParkedVehicles { get; }
        void Park(T vehicle);
		void Remove(T vehicle);
		string Information();
	}
}
