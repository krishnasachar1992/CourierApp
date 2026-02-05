namespace CourierApp.Offers;

public class Ofr001 : OfferBase
{
    public override decimal DiscountPercent => 0.10m;
    protected override int MinWeight => 70;
    protected override int MaxWeight => 200;
    protected override int MinDistance => 0;
    protected override int MaxDistance => 199;
}
