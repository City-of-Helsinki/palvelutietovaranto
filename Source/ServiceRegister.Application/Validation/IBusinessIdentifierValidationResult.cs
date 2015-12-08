namespace ServiceRegister.Application.Validation
{
    public interface IBusinessIdentifierValidationResult
    {
        bool IsValid { get; }
        string ReasonForInvalidity { get; }
    }
}
