using CourierApp.Domain;
using CourierApp.Offers;
using FluentAssertions;

public class OfferTests
{
    [Fact]
    public void Ofr001_Should_Be_Applicable()
    {
        var offer = new Ofr001();
        var pkg = new Package("P", 100, 50, "OFR001");

        offer.IsApplicable(pkg).Should().BeTrue();
    }

    [Fact]
    public void Ofr001_Should_Fail_When_Weight_Low()
    {
        var offer = new Ofr001();
        var pkg = new Package("P", 10, 50, "OFR001");

        offer.IsApplicable(pkg).Should().BeFalse();
    }
}
