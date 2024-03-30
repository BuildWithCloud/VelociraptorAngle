namespace Velociraptor_Angle;

public struct ReturnFromSim(double time, WhoWon whoWon, double margin)
{
    public readonly double Time = time;
    public readonly WhoWon WhoWon = whoWon;
    public readonly double Margin = margin;
}

public enum WhoWon
{
    Healthy,
    Injured,
}