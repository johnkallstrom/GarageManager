namespace GarageManager.Garage.Exceptions
{
	internal class GarageIsFullException : Exception
	{
		public GarageIsFullException()
		{
		}

		public override string Message => "The garage is full";
	}
}
