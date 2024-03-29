namespace Velociraptor_Angle;

public abstract class Character
{
    public double[] Position; // x, y
    public double[] Velocity; // x, y
    public double Acceleration; // magnitude
    
    public Character(double[] position, double[] velocity, double acceleration)
    {
        Position = position;
        Velocity = velocity;
        Acceleration = acceleration;
    }
    
    public double GetAngleTo (Character target)
    {
        var dx = target.Position[0] - Position[0];
        var dy = target.Position[1] - Position[1];
        return Math.Atan2(dy, dx);
    }

    public abstract void CalculateNewPosition(double timeStep);
    public abstract void CalculateNewVelocity(double timeStep, Character target);

}