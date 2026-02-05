using CourierApp.Domain;

namespace CourierApp.Services;

public class ShipmentPlanner
{
    public List<Package> SelectShipment(List<Package> remaining, int maxWeight)
    {
        var best = new List<Package>();

        int n = remaining.Count;

        for (int mask = 1; mask < (1 << n); mask++)
        {
            var temp = new List<Package>();
            int weight = 0;

            for (int i = 0; i < n; i++)
            {
                if ((mask & (1 << i)) != 0)
                {
                    temp.Add(remaining[i]);
                    weight += remaining[i].Weight;
                }
            }

            if (weight > maxWeight) continue;

            if (IsBetter(temp, best))
                best = temp;
        }

        return best;
    }

    private bool IsBetter(List<Package> a, List<Package> b)
    {
        if (a.Count != b.Count)
            return a.Count > b.Count;

        return a.Sum(x => x.Weight) > b.Sum(x => x.Weight);
    }
}
