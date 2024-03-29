namespace Velociraptor_Angle;

class Program
{
    static void Main(string[] args)
    {
        Simulation simulation = new Simulation();
        Console.WriteLine(simulation.Simulate());
    }
}