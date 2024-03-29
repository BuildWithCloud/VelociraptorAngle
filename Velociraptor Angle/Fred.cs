namespace Velociraptor_Angle;

public class Fred : Character
{
    private const double Speed = 6;
    public Fred (double startingAngle) : base(new double[] {0, 0}, new double[] {Speed * Math.Cos(startingAngle), Speed * Math.Sin(startingAngle)}, 0)
    {
        
    }
    
    public override void CalculateNewPosition(double timeStep)
    {
        Position = new double[] {Position[0] + Velocity[0] * timeStep, Position[1] + Velocity[1] * timeStep};
    }
    
    public override void CalculateNewVelocity(double timeStep, Character target)
    {
        //does nothing as acceleration of person is 0 (therefore velocity is constant)
    }
    
}