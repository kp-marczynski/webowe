namespace Shop.BusinessObjects.Enums
{
    public enum OrderProcessingState
    {
        VerificationFailed,
        NotVerified,
        Verified,
        PaymentAccepted,
        InRealization,
        InShipping,
        Delivered
    }
}