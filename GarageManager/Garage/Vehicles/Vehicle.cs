namespace GarageManager.Garage.Vehicles
{
	internal class Vehicle : IVehicle
	{
		public string RegistrationNumber { get; set; }
		public string Color { get; set; }
		public int NumberOfWheels { get; set; }

		public Vehicle(string registrationNumber, string color, int numberOfWheels)
		{
			RegistrationNumber = registrationNumber;
			Color = color;
			NumberOfWheels = numberOfWheels;
		}
	}
}
