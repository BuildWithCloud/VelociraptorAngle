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
        double [] acceleration = new double[] {Acceleration * Math.Cos(angle), Acceleration * Math.Sin(angle)};
        Velocity = new double[] {Velocity[0] + acceleration[0] * timeStep, Velocity[1] + acceleration[1] * timeStep};
        if(Utilities.GetMagnitude(Velocity) > maxSpeed)
        {
            Velocity = new double[] {maxSpeed * Math.Cos(angle), maxSpeed * Math.Sin(angle)};
            Console.WriteLine("Velociraptor reached max speed of" + maxSpeed);
        }
    }
}