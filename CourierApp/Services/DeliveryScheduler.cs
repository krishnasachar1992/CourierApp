using CourierApp.Domain;

namespace CourierApp.Services;

public class DeliveryScheduler
{
    public void Schedule(
        List<Package> packages,
        int vehiclesCount,
        int speed,
        int maxWeight)
    {
        var vehicles = new PriorityQueue<Vehicle, double>();

        for (int i = 0; i < vehiclesCount; i++)
            vehicles.Enqueue(new Vehicle(i), 0);

        var planner = new ShipmentPlanner();

        var remaining = new List<Package>(packages);

        while (remaining.Any())
        {
            var shipment = planner.SelectShipment(remaining, maxWeight);

            var vehicle = vehicles.Dequeue();

            double start = vehicle.AvailableAt;
            int maxDist = shipment.Max(x => x.Distance);

            double tripTime = (double)maxDist / speed;

            foreach (var pkg in shipment)
                pkg.DeliveryTime = start + tripTime;

            vehicle.AvailableAt = start + (2 * tripTime);

            vehicles.Enqueue(vehicle, vehicle.AvailableAt);

            remaining.RemoveAll(p => shipment.Contains(p));
        }
    }
}
