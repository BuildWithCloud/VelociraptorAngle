namespace Velociraptor_Angle;

public static class Utilities
{
    public static double GetMagnitude(double[] vector)
    {
        double sum = 0;
        foreach (var component in vector)
        {
            sum += component * component;
        }
        return Math.Sqrt(sum);
    }
    public static double GetDistanceBetween(Character character1, Character character2)
    {
        var dx = character1.Position[0] - character2.Position[0];
        var dy = character1.Position[1] - character2.Position[1];
        return GetMagnitude(new double[] { dx, dy });
    }
}