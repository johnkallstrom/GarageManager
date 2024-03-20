namespace GarageManager.Garage
{
	internal interface IGarage<T> : IEnumerable<T> where T : IVehicle
	{
        T[] Vehicles { get; }
        void Park(T vehicle);
		void Remove(T vehicle);
	}
}
