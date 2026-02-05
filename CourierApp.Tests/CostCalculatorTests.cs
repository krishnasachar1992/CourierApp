using CourierApp.Domain;
using CourierApp.Services;
using FluentAssertions;

public class CostCalculatorTests
{
    private readonly CostCalculator _calc = new();

    [Fact]
    public void Should_Calculate_Cost_Without_Offer()
    {
        var pkg = new Package("PKG1", 10, 10, "NA");

        _calc.Calculate(pkg, 100);

        pkg.TotalCost.Should().Be(250);
        pkg.Discount.Should().Be(0);
    }

    [Fact]
    public void Should_Apply_OFR001_Discount()
    {
        var pkg = new Package("PKG2", 80, 40, "OFR001");

        _calc.Calculate(pkg, 100);

        pkg.Discount.Should().Be(110);
        pkg.TotalCost.Should().Be(990);
    }
}
