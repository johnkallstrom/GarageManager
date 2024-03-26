namespace GarageManager.Garage.Vehicles
{
	internal class Spacecraft : Vehicle
	{
        public SpaceflightPurpose Purpose { get; set; }

        public Spacecraft(string registrationNumber, string color, int numberOfWheels, SpaceflightPurpose purpose) : base(registrationNumber, color, numberOfWheels)
		{
			Purpose = purpose;
		}

		public Spacecraft(string registrationNumber, string color, int numberOfWheels) : base(registrationNumber, color, numberOfWheels)
		{
		}
	}
}
