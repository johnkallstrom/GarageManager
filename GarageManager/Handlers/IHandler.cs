﻿namespace GarageManager.Handlers
{
	internal interface IHandler
	{
		IVehicle GetByRegNumber(string registrationNumber);
		IEnumerable<IVehicle> Search(string searchTerm, SearchCategory category);
		void PopulateGarage(int amount);
		void Remove(IVehicle vehicle);
		void Park(IVehicle vehicle);
		IEnumerable<IVehicle> GetAllVehicles();
		string Information();
		Dictionary<string, int> GetNumberOfVehicles();
	}
}
