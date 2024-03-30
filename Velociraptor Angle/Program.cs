namespace Velociraptor_Angle;

class Program
{
    static void Main(string[] args)
    {
        var simulation = new Simulation();
        Console.WriteLine(simulation.Simulate());
    }
}