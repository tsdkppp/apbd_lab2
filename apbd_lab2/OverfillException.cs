namespace APBD_tutorial2;

public class OverfillException : Exception
{
    public OverfillException(string message) : base(message) { }
}