namespace Velociraptor_Angle;

public class Simulation(double startingAngle, double timeStep, double precision)
{
    private readonly Fred _fred = new(startingAngle);
    private readonly InjuredVelociraptor _injuredVelociraptor = new(new double[] { 0, 10/Math.Cos(0.523599) });
    private readonly HealthyVelociraptor _healthyVelociraptor = new(new double[] { 10, -10 * Math.Tan(0.523599) });
    private double _time;


    public ReturnFromSim Simulate()
    {
        while(Utilities.GetDistanceBetween(_fred, _healthyVelociraptor) > precision && Utilities.GetDistanceBetween(_fred, _injuredVelociraptor) > precision)
        {
            _fred.CalculateNewVelocity(timeStep, _healthyVelociraptor);
            _fred.CalculateNewPosition(timeStep);
            _healthyVelociraptor.CalculateNewVelocity(timeStep, _fred);
            _healthyVelociraptor.CalculateNewPosition(timeStep);
            _injuredVelociraptor.CalculateNewVelocity(timeStep, _fred);
            _injuredVelociraptor.CalculateNewPosition(timeStep);
            _time += timeStep;
        }
        if (Utilities.GetDistanceBetween(_fred, _healthyVelociraptor) < precision)
        {
            return new ReturnFromSim(_time, WhoWon.Healthy);
        }
        else
        {
            return new ReturnFromSim(_time, WhoWon.Injured);
        }
    }

    
    
}