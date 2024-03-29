namespace Velociraptor_Angle;

public class Fred : Character
{
    private new const double Speed = 6;
    public Fred (double StartingAngle) : base(new double[] {0, 0}, new double[] {Speed * Math.Cos(StartingAngle), Speed * Math.Sin(StartingAngle)}, 0)
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