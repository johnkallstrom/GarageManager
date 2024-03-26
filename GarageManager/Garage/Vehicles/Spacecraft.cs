namespace GarageManager.Garage.Vehicles
{
	internal class Spacecraft : Vehicle
	{
		public SpaceflightPurpose Purpose { get; set; } = SpaceflightPurpose.Exploration;

		public Spacecraft(string registrationNumber, string color, int numberOfWheels) : base(registrationNumber, color, numberOfWheels)
		{
		}

		public Spacecraft(string registrationNumber, string color, int numberOfWheels, SpaceflightPurpose purpose) : base(registrationNumber, color, numberOfWheels)
		{
			Purpose = purpose;
		}

		public override string ToString()
		{
			return $"{base.ToString()}\nPurpose of spaceflight: {Purpose}";
		}
	}
}
