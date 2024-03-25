namespace GarageManager.Tests
{
	public class GarageTests
	{
		[Fact]
		public void AvailableSpots_ShouldIncreaseByOne_WhenVehicleIsRemovedFromGarage()
		{
			// Arrange
			IVehicle vehicleToRemove = new Spaceship("BLQ123", "Gray", 0);

			var garage = new Garage<IVehicle>(10);
			garage.Initialize(new List<IVehicle>
			{
				new Spaceship("MVQ456", "Black", 0),
				new Spaceship("VHF041", "Purple", 0),
				vehicleToRemove,
			});

			int expected = garage.AvailableSpots + 1;

			// Act
			Action act = () => garage.Remove(vehicleToRemove);
			act.Invoke();

			// Assert
			int actual = garage.AvailableSpots;
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void AvailableSpots_ShouldDecreaseByOne_WhenNewVehicleIsParked()
		{
			// Arrange
			var garage = new Garage<IVehicle>(10);
			garage.Initialize(new List<IVehicle>
			{
				new Spaceship("BLQ123", "Gray", 0),
				new Spaceship("MVQ456", "Black", 0),
				new Spaceship("VHF041", "Purple", 0),
			});

			IVehicle vehicle = new Spaceship("FPQ981", "Yellow", 0);
			int expected = garage.AvailableSpots - 1;

			// Act
			Action act = () => garage.Park(vehicle);
			act.Invoke();

			// Assert
			int actual = garage.AvailableSpots;
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void Park_Should_ThrowArgumentNullException_WhenVehicleIsNull()
		{
			// Arrange
			var garage = new Garage<IVehicle>(5);
			IVehicle vehicle = null!;

			// Act
			Action act = () => garage.Park(vehicle);

			// Assert
			Assert.Throws<ArgumentNullException>(act);
		}

		[Fact]
		public void Park_Should_ThrowGarageIsFullException_WhenGarageIsFull()
		{
			// Arrange
			var garage = new Garage<IVehicle>(3);
			garage.Initialize(new List<IVehicle>
			{
				new Spaceship("BLQ123", "Gray", 0),
				new Spaceship("MVQ456", "Black", 0),
				new Spaceship("PDS093", "Purple", 0),
			});

			IVehicle vehicle = new Spaceship("UQP", "Yellow", 0);

			// Act
			Action act = () => garage.Park(vehicle);

			// Assert
			Assert.Throws<GarageIsFullException>(act);
		}

		[Fact]
		public void Park_Should_ThrowException_WhenRegistrationNumberAlreadyExists()
		{
			// Arrange
			var garage = new Garage<IVehicle>(3);
			garage.Initialize(new List<IVehicle>
			{
				new Spaceship("BLQ123", "Gray", 0),
				new Spaceship("MVQ456", "Black", 0),
			});

			IVehicle vehicle = new Spaceship("BLQ123", "Yellow", 0);

			// Act
			Action act = () => garage.Park(vehicle);

			// Assert
			Assert.Throws<Exception>(act);
		}
	}
}
