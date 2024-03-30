namespace Velociraptor_Angle;

public abstract class Character(double[] position, double[] velocity, double acceleration)
{
    public double[] Position = position; // x, y
    protected double[] Velocity = velocity; // x, y
    protected readonly double Acceleration = acceleration; // magnitude

    public double GetAngleTo (Character target)
    {
        var dx = target.Position[0] - Position[0];
        var dy = target.Position[1] - Position[1];
        return Math.Atan2(dy, dx);
    }

    public abstract void CalculateNewPosition(double timeStep);
    public abstract void CalculateNewVelocity(double timeStep, Character target);

}