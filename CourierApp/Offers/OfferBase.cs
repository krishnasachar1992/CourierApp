using CourierApp.Domain;

namespace CourierApp.Offers;

public abstract class OfferBase : IOfferStrategy
{
    public abstract decimal DiscountPercent { get; }
    protected abstract int MinWeight { get; }
    protected abstract int MaxWeight { get; }
    protected abstract int MinDistance { get; }
    protected abstract int MaxDistance { get; }

    public bool IsApplicable(Package pkg)
    {
        return pkg.Weight >= MinWeight && pkg.Weight <= MaxWeight &&
               pkg.Distance >= MinDistance && pkg.Distance <= MaxDistance;
    }
}
