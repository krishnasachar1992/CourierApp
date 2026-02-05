using CourierApp.Domain;
using CourierApp.Services;

Console.WriteLine("===Hi, Welcome to Lightning Courier Service===");
Console.WriteLine("Please enter the base cost");
int baseCost = int.Parse(Console.ReadLine());

Console.WriteLine("Please enter the number of packages");
int n = int.Parse(Console.ReadLine());

var packages = new List<Package>();
Console.WriteLine("Enter the " + n + " package details");

for (int i = 0; i < n; i++)
{
    var p = Console.ReadLine()!.Split();
    packages.Add(new Package(p[0], int.Parse(p[1]), int.Parse(p[2]), p[3]));
}

Console.WriteLine("Please enter the no of vehicles, speed, maxweight");
var last = Console.ReadLine()!.Split();

//Reading all the values from console.
int vehicles = int.Parse(last[0]);
int speed = int.Parse(last[1]);
int maxWeight = int.Parse(last[2]);

var calculator = new CostCalculator();

foreach (var pkg in packages)
    calculator.Calculate(pkg, baseCost);

var scheduler = new DeliveryScheduler();
scheduler.Schedule(packages, vehicles, speed, maxWeight);

foreach (var pkg in packages)
{
    Console.WriteLine("\n");
    Console.WriteLine($"Id : {pkg.Id} Discount : {pkg.Discount:F0} Total Cost : {pkg.TotalCost:F0} Delivery Time : {pkg.DeliveryTime:F2}");
}
