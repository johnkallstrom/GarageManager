﻿namespace GarageManager.Handlers
{
	internal interface IHandler
	{
		void Populate();
		void Remove(IVehicle vehicle);
		void Park(IVehicle vehicle);
		IEnumerable<IVehicle> GetAll();
		string GetInformation();
		Dictionary<string, int> GetAmountByType();
	}
}
