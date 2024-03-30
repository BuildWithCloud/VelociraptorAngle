namespace Velociraptor_Angle;

public class Simulation
{
    private readonly Fred _fred;
    private readonly InjuredVelociraptor _injuredVelociraptor;
    private readonly HealthyVelociraptor _healthyVelociraptor;
    private double _time;
    private const double TimeStep = 0.0001; 
    private const double Precision = 0.1;
    
    
    public Simulation()
    {
        _fred = new Fred(GetStartingAngle());
        _injuredVelociraptor = new InjuredVelociraptor(new double[] { 0, 10/Math.Cos(0.523599) });
        _healthyVelociraptor = new HealthyVelociraptor(new double[] { 10, -10 * Math.Tan(0.523599) });
    }

    public ReturnFromSim Simulate()
    {
        while(Utilities.GetDistanceBetween(_fred, _healthyVelociraptor) > Precision && Utilities.GetDistanceBetween(_fred, _injuredVelociraptor) > Precision)
        {
            _fred.CalculateNewVelocity(TimeStep, _healthyVelociraptor);
            _fred.CalculateNewPosition(TimeStep);
            _healthyVelociraptor.CalculateNewVelocity(TimeStep, _fred);
            _healthyVelociraptor.CalculateNewPosition(TimeStep);
            _injuredVelociraptor.CalculateNewVelocity(TimeStep, _fred);
            _injuredVelociraptor.CalculateNewPosition(TimeStep);
            _time += TimeStep;
        }
        if (Utilities.GetDistanceBetween(_fred, _healthyVelociraptor) < Precision)
        {
            return new ReturnFromSim(_time, WhoWon.Healthy);
        }
        else
        {
            return new ReturnFromSim(_time, WhoWon.Injured);
        }
    }

    private double GetStartingAngle()
    {
        Console.WriteLine("Please enter starting angle (radians)");
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
        return angle;
    }
    
}