namespace CourierApp.Offers;

public static class OfferFactory
{
    private static readonly Dictionary<string, IOfferStrategy> _offers =
        new()
        {
            ["OFR001"] = new Ofr001(),
            ["OFR002"] = new Ofr002(),
            ["OFR003"] = new Ofr003()
        };

    public static IOfferStrategy? Get(string code)
        => _offers.TryGetValue(code, out var offer) ? offer : null;
}
