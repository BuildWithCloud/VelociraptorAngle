namespace Velociraptor_Angle;

public class Simulation(double startingAngle, double precision)
{
    private readonly Fred _fred = new(startingAngle);
    private readonly InjuredVelociraptor _injuredVelociraptor = new(new double[] { 0, 10/Math.Cos(0.523599) });
    private readonly HealthyVelociraptor _healthyVelociraptor = new(new double[] { 10, -10 * Math.Tan(0.523599) });
    private double _time;
    private readonly double _timeStep = precision/31; // This is the worst case closing speed (25 + 6) this would never happen, but is safe


    public ReturnFromSim Simulate()
    {
        while(Utilities.GetDistanceBetween(_fred, _healthyVelociraptor) > precision && Utilities.GetDistanceBetween(_fred, _injuredVelociraptor) > precision)
        {
            _fred.CalculateNewVelocity(_timeStep, _healthyVelociraptor);
            _fred.CalculateNewPosition(_timeStep);
            _healthyVelociraptor.CalculateNewVelocity(_timeStep, _fred);
            _healthyVelociraptor.CalculateNewPosition(_timeStep);
            _injuredVelociraptor.CalculateNewVelocity(_timeStep, _fred);
            _injuredVelociraptor.CalculateNewPosition(_timeStep);
            _time += _timeStep;
        }
        if (Utilities.GetDistanceBetween(_fred, _healthyVelociraptor) < precision)
        {
            return new ReturnFromSim(_time, WhoWon.Healthy, Utilities.GetDistanceBetween(_fred, _injuredVelociraptor) - Utilities.GetDistanceBetween(_fred, _healthyVelociraptor));
        }
        else
        {
            return new ReturnFromSim(_time, WhoWon.Injured, Utilities.GetDistanceBetween(_fred, _healthyVelociraptor) - Utilities.GetDistanceBetween(_fred, _injuredVelociraptor));
        }
    }

    
    
}