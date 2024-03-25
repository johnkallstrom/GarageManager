namespace GarageManager.Garage.Exceptions
{
	internal class GarageIsFullException : Exception
	{
		public GarageIsFullException()
		{
		}

		public GarageIsFullException(string? message) : base(message)
		{
		}

		public GarageIsFullException(string? message, Exception? innerException) : base(message, innerException)
		{
		}

		public override string Message => "The garage is full";
	}
}
