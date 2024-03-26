namespace GarageManager.Garage.Vehicles
{
	internal class Boat : Vehicle
	{
        public BoatPropulsion Propulsion { get; set; }

        public Boat(string registrationNumber, string color, int numberOfWheels, BoatPropulsion propulsion) : base(registrationNumber, color, numberOfWheels)
		{
			Propulsion = propulsion;
		}
	}
}
