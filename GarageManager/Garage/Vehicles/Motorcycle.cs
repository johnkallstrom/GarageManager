﻿namespace GarageManager.Garage.Vehicles
{
	internal class Motorcycle : Vehicle
	{
        public int TopSpeed { get; set; }

        public Motorcycle(string registrationNumber, string color, int numberOfWheels, int topSpeed) : base(registrationNumber, color, numberOfWheels)
		{
			TopSpeed = topSpeed;
		}

		public override string ToString()
		{
			return $"{base.ToString()}\nTop speed: {TopSpeed} km/h";
		}
	}
}
