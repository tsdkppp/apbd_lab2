using System.Security.Cryptography;

namespace APBD_tutorial2;

public abstract class Container
{
    public static int Counter = 1;
    public int Id { get; set; } = Counter++;
    public double MassOfCargo { get; set; }
    public double Height { get; set; }
    public double TareWeight { get; set; }
    public double Depth { get; set; }
    public string SerialNumber { get; set; }
    public double MaxPayLoad { get; set; }
    public Container (char c, double height, double tareWeight, double depth, double maxPayLoad)
    {
        SerialNumber = $"KON-{c}-{Id}";
        Height = height;
        TareWeight = tareWeight;
        Depth = depth;
        MaxPayLoad = maxPayLoad;
    }

    public virtual void LoadContainer(double massOfCargo)
    {
        double massOfCargoWillBe = MassOfCargo + massOfCargo;
        if (massOfCargoWillBe > MaxPayLoad)
        {
            throw new OverfillException("Cannot load cargo, exceeds maximum capacity");
        }
        MassOfCargo = massOfCargoWillBe; 
    }
    public virtual void EmptyCargo()
    {
        MassOfCargo = 0;
    }
    public void PrintInformationAboutContainer()
    {
        Console.WriteLine($"Container: \"{SerialNumber}\"," +
                          $" Id = \"{Id}\"," +
                          $" Height = \"{Height}\"," +
                          $" Depth = \"{Depth}\"," +
                          $" MaxPayLoad = \"{MaxPayLoad}\"," +
                          $" Tare Weight = \"{TareWeight}\" kg," +
                          $" Cargo Weight = \"{MassOfCargo}\" kg"
        );
    }
}