using System.Diagnostics.Metrics;

namespace Velociraptor_Angle;

class Program
{
    static void Main(string[] args)
    {
        double angle = FindOptimalAngle(0, Math.PI/2, 0.0000000000001);
        Console.WriteLine($"Optimal angle is {double.RadiansToDegrees(angle)}");
    }

    private static double FindOptimalAngle(double lowerBound, double upperBound, double requiredPrecision)
    {
        double precision = 1;
        double angle = (lowerBound + upperBound) / 2;
        while(upperBound - lowerBound > requiredPrecision)
        {
            angle = (lowerBound + upperBound) / 2;
            Console.WriteLine($"Simulating angle {double.RadiansToDegrees(angle)}, precision {precision}");
            var sim = new Simulation(angle, precision);
            var result = sim.Simulate();
            precision = result.Margin / 2;
            if(result.WhoWon == WhoWon.Healthy)
            {
                lowerBound = angle;
                Console.WriteLine($"Healthy Won in {result.Time} by {result.Margin}");
            }
            else
            {
                upperBound = angle;
                Console.WriteLine($"Injured Won in {result.Time} by {result.Margin}");
            }

        }
        return angle;
    }
}