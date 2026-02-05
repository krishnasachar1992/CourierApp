namespace CourierApp.Offers;

public class Ofr003 : OfferBase
{
    public override decimal DiscountPercent => 0.05m;
    protected override int MinWeight => 10;
    protected override int MaxWeight => 150;
    protected override int MinDistance => 50;
    protected override int MaxDistance => 250;
}
