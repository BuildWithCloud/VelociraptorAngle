namespace Velociraptor_Angle;

public class Velociraptor(double[] position, double maxSpeed) : Character(position, new double[] { 0, 0 }, 4)
{
    public override void CalculateNewPosition(double timeStep)
    {
        Position = new double[] {Position[0] + Velocity[0] * timeStep, Position[1] + Velocity[1] * timeStep};
    }
    public override void CalculateNewVelocity(double timeStep, Character target)
    {
        var angle = GetAngleTo(target);
        var newVelocity = Utilities.GetMagnitude(Velocity) + Acceleration * timeStep;
        if(newVelocity > maxSpeed)  newVelocity = maxSpeed; 
    
        Velocity = new double[] {newVelocity * Math.Cos(angle), newVelocity * Math.Sin(angle)};
        }
}