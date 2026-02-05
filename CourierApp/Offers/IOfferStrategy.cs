using CourierApp.Domain;

namespace CourierApp.Offers;

public interface IOfferStrategy
{
    bool IsApplicable(Package pkg);
    decimal DiscountPercent { get; }
}
