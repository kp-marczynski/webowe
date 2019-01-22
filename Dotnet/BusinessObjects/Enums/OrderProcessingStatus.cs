namespace Shop.BusinessObjects.Enums
{
    public enum OrderProcessingStatus
    {
        VerificationFailed,
        NotVerified,
        Verified,
        PaymentAccepted,
        InRealization,
        InShipping,
        Delivered,
        UnknownError
    }
}