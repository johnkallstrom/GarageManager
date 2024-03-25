namespace GarageManager.Garage.Exceptions
{
	internal class VehicleDoesNotExistException : Exception
	{
		private string _registrationNumber;

		public VehicleDoesNotExistException(string registrationNumber)
		{
			_registrationNumber = registrationNumber;
		}

		public override string Message => $"Vehicle with '{_registrationNumber}' does not exist";
	}
}
