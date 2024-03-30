namespace Velociraptor_Angle;

public struct ReturnFromSim(double time, WhoWon whoWon)
{
    public readonly double Time = time;
    public readonly WhoWon WhoWon = whoWon;
}

public enum WhoWon
{
    Healthy,
    Injured,
}