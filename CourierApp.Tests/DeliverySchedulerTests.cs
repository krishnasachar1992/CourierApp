using CourierApp.Domain;
using CourierApp.Services;
using FluentAssertions;

public class DeliverySchedulerTests
{
    [Fact]
    public void Should_Calculate_Correct_Delivery_Time()
    {
        var packages = new List<Package>
        {
            new("P1", 50, 60, "NA"), // 1 hour
        };

        var scheduler = new DeliveryScheduler();

        scheduler.Schedule(packages, 1, 60, 200);

        packages[0].DeliveryTime.Should().Be(1.0);
    }

    [Fact]
    public void Should_Use_Earliest_Available_Vehicle()
    {
        var packages = new List<Package>
        {
            new("P1", 50, 60, "NA"),
            new("P2", 50, 60, "NA")
        };

        var scheduler = new DeliveryScheduler();

        scheduler.Schedule(packages, 2, 60, 200);

        packages[0].DeliveryTime.Should().Be(1.0);
        packages[1].DeliveryTime.Should().Be(1.0);
    }
}
