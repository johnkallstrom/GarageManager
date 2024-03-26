namespace GarageManager.Garage.Vehicles
{
	internal class Airplane : Vehicle
	{
        public int NumberOfEngines { get; set; }
        public string Model { get; set; }

        public Airplane(string registrationNumber, string color, int numberOfWheels, string model, int numberOfEngines) : base(registrationNumber, color, numberOfWheels)
		{
			Model = model;
			NumberOfEngines = numberOfEngines;
		}

		public override string ToString()
		{
			return $"{base.ToString()}\nModel: {Model}\nNumber of engines: {NumberOfEngines}";
		}
	}
}
