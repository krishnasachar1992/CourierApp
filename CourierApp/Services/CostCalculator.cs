using CourierApp.Domain;
using CourierApp.Offers;

namespace CourierApp.Services;

public class CostCalculator
{
    public void Calculate(Package pkg, int baseCost)
    {
        decimal cost = baseCost + pkg.Weight * 10 + pkg.Distance * 5;

        var offer = OfferFactory.Get(pkg.OfferCode);

        if (offer != null && offer.IsApplicable(pkg))
            pkg.Discount = cost * offer.DiscountPercent;
        else
            pkg.Discount = 0;

        pkg.TotalCost = cost - pkg.Discount;
    }
}
