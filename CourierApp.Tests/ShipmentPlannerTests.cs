using CourierApp.Domain;
using CourierApp.Services;
using FluentAssertions;

public class ShipmentPlannerTests
{
    [Fact]
    public void Should_Select_Max_Count_Then_Max_Weight()
    {
        var planner = new ShipmentPlanner();

        var packages = new List<Package>
        {
            new("P1", 50, 10, "NA"),
            new("P2", 60, 10, "NA"),
            new("P3", 120, 10, "NA")
        };

        var shipment = planner.SelectShipment(packages, 150);

        shipment.Should().HaveCount(2);
        shipment.Select(x => x.Id)
                .Should().Contain(new[] { "P1", "P2" });
    }
}
