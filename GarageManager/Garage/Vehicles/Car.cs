namespace GarageManager.Garage.Vehicles
{
	internal class Car : Vehicle
	{
        public string Model { get; set; }

        public Car(string registrationNumber, string color, int numberOfWheels, string model) : base(registrationNumber, color, numberOfWheels)
		{
			Model = model;
		}

		public override string ToString()
		{
			return $"{base.ToString()}\nModel: {Model}";
		}
	}
}
