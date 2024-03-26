namespace GarageManager.Tests
{
	public class GarageTests
	{
		[Fact]
		public void GetNumberOfVehicles_Should_ReturnDictionaryWithCountEqualToSix()
		{
			// Arrange
			var garage = new Garage<IVehicle>(5);
			garage.Initialize(new List<IVehicle>
			{
				new Spacecraft("MVQ456", "Black", 0),
				new Spacecraft("VHF041", "Purple", 0),
				new Spacecraft("PLD041", "Purple", 0),
			});

			// Act
			var result = garage.GetNumberOfVehicles();

			// Arrange
			int expected = 6;
			int actual = result.Count;
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void GetNumberOfVehicles_Should_ReturnDictionaryWithStringKeyAndIntValue()
		{
			// Arrange
			var garage = new Garage<IVehicle>(5);
			garage.Initialize(new List<IVehicle>
			{
				new Spacecraft("MVQ456", "Black", 0),
				new Spacecraft("VHF041", "Purple", 0),
				new Spacecraft("PLD041", "Purple", 0),
			});

			// Act
			var result = garage.GetNumberOfVehicles();

			// Arrange
			Assert.IsType<Dictionary<string, int>>(result);
		}

		[Fact]
		public void IsFull_ShouldBeFalse_WhenGarageIsNotFull()
		{
			var garage = new Garage<IVehicle>(5);
			garage.Initialize(new List<IVehicle>
			{
				new Spacecraft("MVQ456", "Black", 0),
				new Spacecraft("VHF041", "Purple", 0),
				new Spacecraft("PLD041", "Purple", 0),
			});

			Assert.False(garage.IsFull);
		}

		[Fact]
		public void IsFull_ShouldBeTrue_WhenGarageIsFull()
		{
			var garage = new Garage<IVehicle>(3);
			garage.Initialize(new List<IVehicle>
			{
				new Spacecraft("MVQ456", "Black", 0),
				new Spacecraft("VHF041", "Purple", 0),
				new Spacecraft("PLD041", "Purple", 0),
			});

			Assert.True(garage.IsFull);
		}

		[Fact]
		public void GetByRegNumber_Should_ThrowVehicleDoesNotExistException_WhenVehicleDoesNotExist()
		{
			// Arrange
			var garage = new Garage<IVehicle>(5);
			garage.Initialize(new List<IVehicle>
			{
				new Spacecraft("MVQ456", "Black", 0),
				new Spacecraft("VHF041", "Purple", 0),
				new Spacecraft("OLM371", "Yellow", 0),
			});

			// Act
			Action act = () => garage.GetByRegNumber("ZEQ913");

			// Assert
			Assert.Throws<VehicleDoesNotExistException>(act);
		}

		[Fact]
		public void GetByRegNumber_ShouldNotReturnNull_WhenVehicleExists()
		{
			// Arrange
			var garage = new Garage<IVehicle>(5);
			garage.Initialize(new List<IVehicle>
			{
				new Spacecraft("MVQ456", "Black", 0),
				new Spacecraft("VHF041", "Purple", 0),
				new Spacecraft("OLM371", "Yellow", 0),
			});

			// Act
			var vehicle = garage.GetByRegNumber("OLM371");

			// Assert
			Assert.NotNull(vehicle);
		}

		[Fact]
		public void TotalSpots_ShouldBe_EqualToCapacity()
		{
			// Arrange
			int capacity = 10;
			var garage = new Garage<IVehicle>(capacity);
			garage.Initialize(new List<IVehicle>
			{
				new Spacecraft("MVQ456", "Black", 0),
				new Spacecraft("VHF041", "Purple", 0),
				new Spacecraft("OLM371", "Yellow", 0),
			});

			Assert.Equal(garage.TotalSpots, capacity);
		}

		[Fact]
		public void AvailableSpots_ShouldIncreaseByOne_WhenVehicleIsRemovedFromGarage()
		{
			// Arrange
			IVehicle vehicleToRemove = new Spacecraft("BLQ123", "Gray", 0);

			var garage = new Garage<IVehicle>(10);
			garage.Initialize(new List<IVehicle>
			{
				new Spacecraft("MVQ456", "Black", 0),
				new Spacecraft("VHF041", "Purple", 0),
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
				new Spacecraft("BLQ123", "Gray", 0),
				new Spacecraft("MVQ456", "Black", 0),
				new Spacecraft("VHF041", "Purple", 0),
			});

			IVehicle vehicle = new Spacecraft("FPQ981", "Yellow", 0);
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
				new Spacecraft("BLQ123", "Gray", 0),
				new Spacecraft("MVQ456", "Black", 0),
				new Spacecraft("PDS093", "Purple", 0),
			});

			IVehicle vehicle = new Spacecraft("UQP", "Yellow", 0);

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
				new Spacecraft("BLQ123", "Gray", 0),
				new Spacecraft("MVQ456", "Black", 0),
			});

			IVehicle vehicle = new Spacecraft("BLQ123", "Yellow", 0);

			// Act
			Action act = () => garage.Park(vehicle);

			// Assert
			Assert.Throws<Exception>(act);
		}

		[Fact]
		public void Park_Should_IncreaseVehiclesLengthByOne_WhenVehicleIsAddedToGarage()
		{
			// Arrange
			var garage = new Garage<IVehicle>(5);
			garage.Initialize(new List<IVehicle>
			{
				new Spacecraft("BLQ123", "Gray", 0),
				new Spacecraft("MVQ456", "Black", 0),
			});

			IVehicle vehicle = new Spacecraft("XQP099", "Yellow", 0);

			// Act
			garage.Park(vehicle);

			// Assert
			int expected = 3;
			int actual = garage.Vehicles.Length;

			Assert.Equal(expected, actual);
		}
	}
}
