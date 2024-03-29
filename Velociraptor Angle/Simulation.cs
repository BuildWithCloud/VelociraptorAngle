namespace Velociraptor_Angle;

public class Simulation
{
    private Fred _fred;
    private InjuredVelociraptor _injuredVelociraptor;
    private HealthyVelociraptor _healthyVelociraptor;
    private double _time;
    private const double TimeStep = 0.00001;
    private const double Precision = 0.1;
    
    
    public Simulation()
    {
        _fred = new Fred(GetStartingAngle());
        _injuredVelociraptor = new InjuredVelociraptor(new double[] { 0, 10/Math.Cos(double.DegreesToRadians(30)) });
        _healthyVelociraptor = new HealthyVelociraptor(new double[] { 10, -10 * Math.Tan(double.DegreesToRadians(30)) });
    }

    public double Simulate()
    {
        while(Utilities.GetDistanceBetween(_fred, _healthyVelociraptor) > Precision && Utilities.GetDistanceBetween(_fred, _injuredVelociraptor) > Precision)
        {
            _fred.CalculateNewVelocity(TimeStep, _healthyVelociraptor);
            _fred.CalculateNewPosition(TimeStep);
            _healthyVelociraptor.CalculateNewVelocity(TimeStep, _fred);
            _healthyVelociraptor.CalculateNewPosition(TimeStep);
            _time += TimeStep;
            Console.WriteLine("h" + Utilities.GetDistanceBetween(_fred, _healthyVelociraptor));
            Console.WriteLine("i" + Utilities.GetDistanceBetween(_fred, _injuredVelociraptor));
        }
        return _time;
    }

    private double GetStartingAngle()
    {
        Console.WriteLine("Please enter starting angle (degrees)");
        string? input = null;
        var angle = 0.0; // degrees
        while (input == null)
        {
            try
            {
                input = Console.ReadLine();
                if (input == null)
                {
                    throw new Exception();
                }
                angle = double.Parse(input);
                return angle;
            }
            catch
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
        return double.DegreesToRadians(angle);

    }
}