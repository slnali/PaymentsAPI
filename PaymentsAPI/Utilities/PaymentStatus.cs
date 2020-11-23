namespace PaymentsAPI.Utilities
{
    /// <summary>
    /// Enum for defining Payment Status. Only Failure and success  used but others defined as potentials... 
    /// </summary>
    public enum PaymentStatus
    {
        Failure = 0,
        Success = 1,
        AlreadyExists = 2,
        ValidationFailed = 3,
        NotFound = 4,
        Accepted = 5,
        NotAuthorised = 6
    }
}
