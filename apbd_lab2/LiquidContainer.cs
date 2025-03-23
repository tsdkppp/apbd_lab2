namespace APBD_tutorial2;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsHazardousCargo { get; }
    public LiquidContainer(bool isHazardousCargo, double height, double tareWeight, double depth, double maxPayLoad)
        : base('L', height, tareWeight, depth, maxPayLoad)
    {
        IsHazardousCargo = isHazardousCargo;
    }
    public void SendNotification()
    {
        Console.WriteLine($"Hazard alert! Container: \"{SerialNumber}\"");
    }
    public override void LoadContainer(double massOfCargo)
    {
        double allowedCapacity = 0;
        if (IsHazardousCargo) {
            allowedCapacity = MaxPayLoad * 0.5;
        }
        else {
            allowedCapacity = MaxPayLoad * 0.9;
        }
        if (massOfCargo > allowedCapacity) {
            SendNotification();
            throw new OverfillException($"Cargo exceeds allowed capacity of \"{allowedCapacity}\" kg.");
        }
        base.LoadContainer(massOfCargo);
    }
}