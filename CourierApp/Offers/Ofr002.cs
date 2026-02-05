namespace CourierApp.Offers;

public class Ofr002 : OfferBase
{
    public override decimal DiscountPercent => 0.07m;
    protected override int MinWeight => 100;
    protected override int MaxWeight => 250;
    protected override int MinDistance => 50;
    protected override int MaxDistance => 150;
}
