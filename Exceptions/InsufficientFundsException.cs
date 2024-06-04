namespace VehicleFleet.Api.Exceptions;
[Serializable]
public class InsufficientFundsException : Exception
{
    public long IDNumber { get; }
    public InsufficientFundsException()
    {}
    public InsufficientFundsException(string message) : base(message)
    {}
    public InsufficientFundsException(string message, Exception inner) : base(message, inner)
    {}
    public InsufficientFundsException(string message, long idNumber) : this(message)
    {
        IDNumber = idNumber;
    }
}