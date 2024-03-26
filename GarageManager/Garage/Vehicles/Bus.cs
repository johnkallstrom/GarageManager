namespace GarageManager.Garage.Vehicles
{
	internal class Bus : Vehicle
	{
        public bool IsDoubleDecker { get; set; }

        public Bus(string registrationNumber, string color, int numberOfWheels, bool isDoubleDecker) : base(registrationNumber, color, numberOfWheels)
		{
			IsDoubleDecker = isDoubleDecker;
		}

		public override string ToString()
		{
			return $"{base.ToString()}\nIs double decker: {IsDoubleDecker}";
		}
	}
}
